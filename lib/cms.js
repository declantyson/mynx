	var delCode = '<span class="del-col">X</span>',
		movCode = '<span class="move-col">&nbsp;</span>',
		editCode = '<span class="editable-col">&nbsp;</span>',
		reduceCode = '<span class="reduce-col">&nbsp;</span>',
		increaseCode = '<span class="increase-col">&nbsp;</span>',
		contentBox = '<div class="content-box"><div class="widget-col col-33 new-col"><p class="new-html">Add raw HTML column</p></div><div class="clearfix"></div></div>',
		defaultHtmlColumn = "<div class='col col-33 html-col movable resizable edit-col'><textarea></textarea></div>",
		widgetColumn = '<div class="widget-col col-33 new-col"><p class="new-html">Add raw HTML column</p></div><div class="clearfix"></div>',
		$edit = $('.editable-content');

    $('.editable-content, .editable-content .content-box').sortable({
    	handle: '.move-col'
    });

	$('.widget').each(function(){
		addControls($(this).parent());
	});

	$('.text-data').each(function(){
		var data = $(this).html();
		$(this).html('<input type="text" value="' + data + '"/>');
	});

    $edit.find('.content-box').each(function(){
    	$(this).append(widgetColumn);
    });

	$edit.find('.html-col').each(function(){
		var $this = $(this);
		$this.html("<textarea>" + $(this).html() + "</textarea>");
		$this.addClass('edit-col');
		addControls($this);
	});

	for (var widget in widgetCode) {
		var additionCode = "<p class='new-widget' data-widget='" + widget + "'>New " + widget +"</p>";
		$('.widget-col').append(additionCode);
	}

	$('.increase-col').live('click', function(){
		var $col = $(this).closest('.edit-col');
		if($col.hasClass('col-25')) {
			$col.removeClass('col-25').addClass('col-33');
			$(this).before(reduceCode);
		} else if ($col.hasClass('col-33')) {
			$col.removeClass('col-33').addClass('col-50');
		} else if($col.closest('.edit-col').hasClass('col-50')) {
			$col.removeClass('col-50').addClass('col-66');
		} else if($col.closest('.edit-col').hasClass('col-66')) {
			$col.removeClass('col-66').addClass('col-75');
		} else if($col.closest('.edit-col').hasClass('col-75')) {
			$col.removeClass('col-75').addClass('col-100');
			$(this).remove();
		}
	});	

	$('.reduce-col').live('click', function(){
		var $col = $(this).closest('.edit-col');
		if($col.hasClass('col-100')) {
			$col.removeClass('col-100').addClass('col-75');
			$(this).after(increaseCode);
		} else if($col.closest('.edit-col').hasClass('col-75')) {
			$col.removeClass('col-75').addClass('col-66');
		} else if($col.closest('.edit-col').hasClass('col-66')) {
			$col.removeClass('col-66').addClass('col-50');
		} else if($col.closest('.edit-col').hasClass('col-50')) {
			$col.removeClass('col-50').addClass('col-33');
		} else if($col.closest('.edit-col').hasClass('col-33')) {
			$col.removeClass('col-33').addClass('col-25');
			$(this).remove();
		}
	});	

	$('.del-col').live('click', function(){
		var $col = $(this).closest('.edit-col');
		if(confirm('Delete this column?')) $col.remove();
	});

	$('.editable-col').live('click', function(){
		if($(this).closest('.edit-col').find('.upload-form')) {
			alert('Please upload an image first');
			return false;
		}
		var $col = $(this).siblings('.col-content'),
			html = $col.html();
		$col.html('<textarea>' + html + '</textarea>');
		$(this).removeClass('editable-col').addClass('revert-col');
	});

	$('.revert-col').live('click', function(){
		var $textarea = $(this).siblings('.col-content').find('textarea');
		$textarea.replaceWith($textarea.val());
		$(this).removeClass('revert-col').addClass('editable-col');
	});

	$('.new-content-box').live('click', function(){
		$edit.append(contentBox);
	});

	$('.main-widget-editor .new-html').live('click', function(){
		var $data = addControls($(defaultHtmlColumn));
		$edit.append($data);
	});

	$('.content-box .new-html').live('click', function(){
		var $data = addControls($(defaultHtmlColumn));
		$(this).parent().before($data);
	});	

	$('.main-widget-editor .new-widget').live('click', function(){
		var $data = $(widgetCode[$(this).data('widget')]);
		$data = addControls($data);
		$edit.append($data);
	});

	$('.content-box .new-widget').live('click', function(){		
		var $data = $(widgetCode[$(this).data('widget')]);
		$data = addControls($data);
		$(this).parent().before($data);
	});

/*	$('.new-image').live('click', function(){
		$.ajax({
			method: "GET",
			url: siteRoot + "hwc/upload"
		}).done(function(data){
			$('.editable-content').append("<div class='col edit-col image-col'><div class='cms-loader'></div><span class='move-col'>&nbsp;</span><span class='del-col'>X</span><span class='reduce-col'>&nbsp;</span><span class='increase-col'>&nbsp;</span>" + data + "</div>");
		});
	});*/

	function rasterizeContent(){
		$('textarea').each(function(){
			$(this).replaceWith($(this).val());
		});

		$('.text-data input').each(function(){
			$(this).replaceWith($(this).val());
		});

		$('.move-col, .del-col, .increase-col, .reduce-col, .upload-form, .widget-col, .editable-col, .revert-col').remove();
		$('#text').val($('.editable-content').html());
	}

	function addControls($this) {
		if($this.hasClass('movable')) { $this.prepend(movCode); }
		if($this.hasClass('editable')) { $this.prepend(editCode); }
		$this.prepend(delCode);
		if($this.hasClass('resizable')) { 
			if(!$this.hasClass('col-25')) {
				$this.prepend(reduceCode); 
			}
			if(!$this.hasClass('col-100')) {
				$this.prepend(increaseCode); 
			}
		}
		return $this;
	}

