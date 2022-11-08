var lastActivityId = "";
var lastActivityPermissions = {};
var roles = [];

function setPermCtrl(areaID, availablePermissions,attrib) {
    // alert('asasas');
    var area = $("#" + areaID);
    console.log(availablePermissions);
    console.log(attrib);

    var rolesDdl = area.find("[data-" + attrib + "-role='roles']");
    var assignedRoles = area.find("[data-" + attrib + "-role='assignedRoles']");
    var notAssignedRoles = area.find("[data-" + attrib + "-role='notAssignedRoles']");
    var assignBtn = area.find("[data-" + attrib + "-role='assign']");
    var deAssignBtn = area.find("[data-" + attrib + "-role='deAssign']");
    var assignAllBtn = area.find("[data-" + attrib + "-role='assignAll']");
    var deAssignAllBtn = area.find("[data-" + attrib + "-role='deAssignAll']");
    console.log(rolesDdl);
    console.log(notAssignedRoles);
    var activityId = area.find("[data-" + attrib + "-role='roles']").attr("data-" + attrib + "-activityId");
    var currentSelectedRole = "";
    //console.log(activityId);    
    if (!roles || roles.length == 0) {
        rolesDdl.find("option").each(function () {
            if ($(this).val()) {
                roles.push($(this).val());
            }
        });
        console.log(roles);      
    }

    var permissions = {};
   // console.log(activityId);
   // console.log(lastActivityId);
    if (activityId != lastActivityId) {
        deAssignBtn.attr("disabled", "disabled");
        assignBtn.attr("disabled", "disabled");
        var permissionsStr = area.find("[data-" + attrib + "-role='value']").val();
        console.log(permissionsStr);
        

        if (permissionsStr) {
            try {
                eval("var item=" + permissionsStr);
                permissions = item;
                console.log(permissions);
            } catch {
                permissions = {};
            }
        }
        for (var i = 0; i < roles.length; i++) {
            if (!permissions[roles[i]]) {
                permissions[roles[i]] = [];
            }
        }

        rolesDdl.change(function () {
            console.log(attrib);
            var selectedRole = rolesDdl.find(":selected").val();
            currentSelectedRole = selectedRole;
            assignedRoles.empty();
            notAssignedRoles.empty();
            for (var i = 0; i < availablePermissions.length; i++) {
                if (permissions[selectedRole].indexOf(availablePermissions[i]) > -1) {
                    assignedRoles.append($('<option>', {
                        value: availablePermissions[i],
                        text: availablePermissions[i]
                    }));
                } else {
                    notAssignedRoles.append($('<option>', {
                        value: availablePermissions[i],
                        text: availablePermissions[i]
                    }));
                }
            }
        });

        notAssignedRoles.change(function () {
            var selectedRoleToAssign = notAssignedRoles.find(":selected").val();
            if (selectedRoleToAssign) {
                assignBtn.removeAttr("disabled");
            } else {
                assignBtn.attr("disabled", "disabled");
            }
           
        });
        assignedRoles.change(function () {
            var selectedRoleToDeAssign = assignedRoles.find(":selected").val();
            if (selectedRoleToDeAssign) {
                deAssignBtn.removeAttr("disabled");
            } else {
                deAssignBtn.attr("disabled", "disabled");
            }
           
        });

        assignBtn.click(function (e) {
            e.preventDefault();
            var selectedRoleToAssign = notAssignedRoles.find(":selected").val();
            if (selectedRoleToAssign) {
                notAssignedRoles.find("option[value = '" + selectedRoleToAssign + "']").remove();
                assignedRoles.append($('<option>', {
                    value: selectedRoleToAssign,
                    text: selectedRoleToAssign
                }));
                setSelectedRolePerm(area, permissions, currentSelectedRole, assignedRoles, attrib);
            }
        });
        deAssignBtn.click(function (e) {
            e.preventDefault();
            var selectedRoleToDeAssign = assignedRoles.find(":selected").val();
            if (selectedRoleToDeAssign) {
                assignedRoles.find("option[value = '" + selectedRoleToDeAssign + "']").remove();
                notAssignedRoles.append($('<option>', {
                    value: selectedRoleToDeAssign,
                    text: selectedRoleToDeAssign
                }));
                setSelectedRolePerm(area, permissions, currentSelectedRole, assignedRoles, attrib);
            }
        });

        assignAllBtn.click(function (e) {
            e.preventDefault();            
            notAssignedRoles.find('option').each(function (index, element) {
                console.log(element);
                if (element.text) {
                    assignedRoles.append($('<option>', {
                        value: element.value,
                        text: element.text
                    }));
                };
            });
            notAssignedRoles.empty();
            setSelectedRolePerm(area, permissions, currentSelectedRole, assignedRoles, attrib);
        });
        deAssignAllBtn.click(function (e) {
            e.preventDefault();
            assignedRoles.find('option').each(function (index, element) {
                if (element.text) {
                    notAssignedRoles.append($('<option>', {
                        value: element.value,
                        text: element.text
                    }));
                };
            });
            assignedRoles.empty();
            setSelectedRolePerm(area, permissions, currentSelectedRole, assignedRoles, attrib);
        });

    }
    

    lastActivityId = activityId;
}
function setSelectedRolePerm(area, permissions, selectedRole, assignedRolesDdl, attrib) {
   permissions[selectedRole]=[];
    assignedRolesDdl.find("option").each(function () {
        if ($(this).val()) {
            permissions[selectedRole].push($(this).val());
        }
    });
    console.log(permissions);
    var finalVal = JSON.stringify(permissions);
    area.find("[data-" + attrib + "-role='value']").val(finalVal);
    area.attr("data-finalval", finalVal);

}
