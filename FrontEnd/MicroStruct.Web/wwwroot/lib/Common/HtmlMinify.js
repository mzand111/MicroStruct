function minifyHtml(html) {
    return html.replace(/\t/ig, "").replace(/\n/ig, "").replace(/\s\s+/ig, "");
}
$.fn.minify = function ()
{
	val=$(this).val();
	
	return val.replace(/\t/ig, "").replace(/\n/ig, "").replace(/\s\s+/ig, "");
}

$.prettify_code=function(el)
{
	function prettify(el)
	{
		if(el.parent().length>0 && el.parent().data('assign'))
		{
			el.data('assign', el.parent().data('assign')+1);
		}
		else
		{
			el.data('assign', 1);
		}
		
		if(el.children().length>0)
		{
			el.children().each
			(
				function()
				{
					tbc='';
					
					for(i=0; i<$(this).parent().data('assign'); i++)
					{
						tbc+='\t';
					}
					$(this).before('\n'+tbc);
					$(this).prepend('\t');
					$(this).append('\n'+tbc);
					prettify($(this));
					
				}
			);
		}
		else
		{
			tbc='';
					
			for(i=0; i<el.parent().data('assign'); i++)
			{
				tbc+='\t';
			}
			el.prepend('\n'+tbc);
		}
	}
	prettify(el);
}

$.fn.show_code=function(code)
{
	$(this).val((code));
}

$.replace_tag=function(val)
{
	val=val.replace(/<html/i, '<div id="replace_html"');
	val=val.replace(/<\/html>/i, '</div>*-html-*');
	
	val=val.replace(/<head/i, '<div id="replace_head"');
	val=val.replace(/<\/head>/i, '</div>*-head-*');
	
	val=val.replace(/<body/i, '<div id="replace_body"');
	val=val.replace(/<\/body>/i, '</div>*-body-*');
	return val;
}

$.undo_tag=function(val)
{
	val=val.replace('<div id="replace_html"', '<html');
	val=val.replace('</div>*-html-*', '</html>');
	
	val=val.replace('<div id="replace_head"', '<head');
	val=val.replace('</div>*-head-*', '</head>');
	
	val=val.replace('<div id="replace_body"', '<body');
	val=val.replace('</div>*-body-*', '</body>');
	return val;
}
