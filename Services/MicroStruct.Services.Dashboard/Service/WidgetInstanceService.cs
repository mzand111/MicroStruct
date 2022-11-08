using MicroStruct.Services.Dashboard.Data.Entities;
using MicroStruct.Services.Dashboard.Domain.Model;
using MicroStruct.Services.Dashboard.Infrastructure.UnitOfWork;
using MZBase.Infrastructure;
using MZBase.Infrastructure.Service;
using MZBase.Infrastructure.Service.Exceptions;
using MZSimpleDynamicLinq.Core;

namespace MicroStruct.Services.Dashboard.Service
{
    public class WidgetInstanceService: StorageBusinessService<WidgetInstance,Guid>
    {
        private readonly IDashboardUnitOfWork _unitOfWork;
        private readonly ILDRCompatibleRepositoryAsync<WidgetInstance, Guid> _baseRepo;


        public WidgetInstanceService(IDashboardUnitOfWork facilityCoreUnitOfWork, IDateTimeProviderService dateTimeProvider, ILogger<WidgetInstance> logger) : base(logger, dateTimeProvider, 600)
        {
            _unitOfWork = facilityCoreUnitOfWork;
            _baseRepo = _unitOfWork.GetRepo<WidgetInstance, Guid>();
        }

        public override async Task<Guid> AddAsync(WidgetInstance item)
        {
            if (item == null)
            {
                var ex = new ServiceArgumentNullException("Input parameter was null:" + nameof(item));
                LogAdd(null, null, ex);
                throw ex;
            }
            await ValidateOnAddAsync(item);

            var g = await _baseRepo.InsertAsync(new WidgetInstanceEntity(item));
            try
            {
                await _unitOfWork.CommitAsync();
                LogAdd(item, "Successfully add item with ,ID:" +
                  g.ID.ToString() +
                  " ,Title:" + item.Title+
                  " ,WidgetID:" + item.WidgetID
                 );
                return g.ID;
            }
            catch (Exception ex)
            {
                LogAdd(item, "Title :" + item.Title+ " ,WidgetID:" + item.WidgetID, ex);
                throw new ServiceStorageException("Error adding company", ex);
            }
        }

        public override async Task<LinqDataResult<WidgetInstance>> ItemsAsync(LinqDataRequest request)
        {
            try
            {
                var f = await _baseRepo.AllItemsAsync(request);
                LogRetrieveMultiple(null, request);
                return f;
            }
            catch (Exception ex)
            {
                LogRetrieveMultiple(null, request, ex);
                throw new ServiceStorageException("Error retrieving the FleetCapacityUnit list ", ex);
            }
        }

        public override async Task ModifyAsync(WidgetInstance item)
        {
            if (item == null)
            {
                var exception = new ServiceArgumentNullException(typeof(WidgetInstance).Name);
                LogModify(item, null, exception);
                throw exception;
            }

            var repo = _unitOfWork.GetRepo<WidgetInstance, Guid>();
            var currentItem = await repo.GetByIdAsync(item.ID);

            if (currentItem == null)
            {
                var noObj = new ServiceObjectNotFoundException(typeof(WidgetInstance).Name + " Not Found");
                LogModify(item, null, noObj);
                throw noObj;
            }
            await ValidateOnModifyAsync(item, currentItem);

            currentItem.LastModifiedBy = item.LastModifiedBy;
            currentItem.LastModificationTime = item.LastModificationTime;
            currentItem.Order = item.Order;
            currentItem.Width = item.Width;
            currentItem.ContainerID = item.ContainerID;
            currentItem.Height = item.Height;
            currentItem.ContainerStructureID = item.ContainerStructureID;
            currentItem.Title = item.Title;
            currentItem.Visible=item.Visible;
            currentItem.WidgetID = item.WidgetID;            
           

            try
            {
                await _unitOfWork.CommitAsync();
                LogModify(item, "Successfully modified item with ,ID:" +
                   item.ID.ToString() +
                   " ,Title:" + item.Title
                 );
            }

            catch (Exception ex)
            {
                LogModify(item, "Title :" + currentItem.Title, ex);
                throw new ServiceStorageException("Error modifing FleetCapacityUnit", ex);
            }
        }

        public override async Task RemoveByIdAsync(Guid ID)
        {
            var itemToDelete = await _baseRepo.FirstOrDefaultAsync(ss => ss.ID == ID);

            if (itemToDelete == null)
            {
                var f = new ServiceObjectNotFoundException(typeof(WidgetInstance).Name + " not found");
                LogRemove(ID, "Item With This Id Not Found", f);
                throw f;
            }
            await _baseRepo.DeleteAsync(itemToDelete);
            try
            {
                await _unitOfWork.CommitAsync();
                LogRemove(ID, "Item Deleted Successfully", null);
            }

            catch (Exception ex)
            {
                var innerEx = new ServiceStorageException("Error deleting item with id" + ID.ToString(), ex);
                LogRemove(ID, null, ex);
                throw innerEx;
            }
        }

        public override async Task<WidgetInstance> RetrieveByIdAsync(Guid ID)
        {
            WidgetInstance? item;
            try
            {
                item = await _baseRepo.FirstOrDefaultAsync(ss => ss.ID == ID);
            }
            catch (Exception ex)
            {
                LogRetrieveSingle(ID, ex);
                throw new ServiceStorageException("Error loading FleetCapacityUnit", ex);
            }
            if (item == null)
            {
                var f = new ServiceObjectNotFoundException(typeof(WidgetInstance).Name + " not found by id");
                LogRetrieveSingle(ID, f);
                throw f;
            }
            LogRetrieveSingle(ID);
            return item;
        }

        protected override async Task ValidateOnAddAsync(WidgetInstance item)
        {
            List<ModelFieldValidationResult> _validationErrors = new List<ModelFieldValidationResult>();

            await CommonValidateAsync(_validationErrors, item);
            ValidateIAuditableOnAdd(_validationErrors, item);

            if (_validationErrors.Any())
            {
                var exp = new ServiceModelValidationException(_validationErrors, "Error validating the model");
                LogAdd(item, "Error in Adding item when validating:" + exp.JSONFormattedErrors, exp);
                throw exp;
            }
        }

        protected override async Task ValidateOnModifyAsync(WidgetInstance recievedItem, WidgetInstance storageItem)
        {
            List<ModelFieldValidationResult> _validationErrors = new List<ModelFieldValidationResult>();

            await CommonValidateAsync(_validationErrors, recievedItem);
            ValidateIAuditableOnModify(_validationErrors, recievedItem, storageItem);

            if (_validationErrors.Any())
            {
                var exp = new ServiceModelValidationException(_validationErrors, "Error validating the model");
                LogModify(recievedItem, "Error in Modifing item when validating:" + exp.JSONFormattedErrors, exp);
                throw exp;
            }
        }
        private async Task CommonValidateAsync(List<ModelFieldValidationResult> validationErrors, WidgetInstance item)
        {
            if (string.IsNullOrWhiteSpace(item.UserName))
            {
                validationErrors.Add(new ModelFieldValidationResult()
                {
                    Code = _logBaseID + 1,
                    FieldName = nameof(item.UserName),
                    ValidationMessage = "The Field Can Not Be Empty"
                });
            }

            if (item.WidgetID==Guid.Empty)
            {
                validationErrors.Add(new ModelFieldValidationResult()
                {
                    Code = _logBaseID + 2,
                    FieldName = nameof(item.WidgetID),
                    ValidationMessage = "The Field Can Not Be Empty"
                });
            }

            //if (string.IsNullOrWhiteSpace(item.Width))
            //{
            //    validationErrors.Add(new ModelFieldValidationResult()
            //    {
            //        Code = _logBaseID + 3,
            //        FieldName = nameof(item.Width),
            //        ValidationMessage = "The Field Can Not Be Empty"
            //    });
            //}
            if (string.IsNullOrWhiteSpace(item.Height))
            {
                validationErrors.Add(new ModelFieldValidationResult()
                {
                    Code = _logBaseID + 4,
                    FieldName = nameof(item.Height),
                    ValidationMessage = "The Field Can Not Be Empty"
                });
            }
            string hs = item.Height.Replace("px", "");
            int hsi;
            if (!int.TryParse(hs,out hsi))
            {
                validationErrors.Add(new ModelFieldValidationResult()
                {
                    Code = _logBaseID + 5,
                    FieldName = nameof(item.Height),
                    ValidationMessage = "Format is incorrect"
                });
            }
            if (hsi < 50)
            {
                validationErrors.Add(new ModelFieldValidationResult()
                {
                    Code = _logBaseID + 6,
                    FieldName = nameof(item.Height),
                    ValidationMessage = "Minimum height is 50px"
                });
            }

        }
    }
}
