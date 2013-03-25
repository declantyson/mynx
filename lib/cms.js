    $('.editable-content, .editable-content .content-box').sortable({
    	handle: '.move-col'
    });

	$('.html-col').each(function(){
		$(this).html("<textarea>" + $(this).html() + "</textarea>");
	});

    $('.editable-content .content-box').each(function(){
    	$(this).append('<div class="widget-col col-33 new-col"><p class="new-html">Add raw HTML column</p></div><div class="clearfix"></div>');
    });

	$('.editable-content .col').each(function(){
		$(this).addClass('edit-col');
		if($(this).hasClass("col-100")) {
			$(this).prepend("<span class='move-col'>&nbsp;</span><span class='del-col'>X</span><span class='reduce-col'>&nbsp;</span>");
		} else if($(this).hasClass("col-25")) {
			$(this).prepend("<span class='move-col'>&nbsp;</span><span class='del-col'>X</span><span class='increase-col'>&nbsp;</span>");
		} else {
			$(this).prepend("<span class='move-col'>&nbsp;</span><span class='del-col'>X</span><span class='reduce-col'>&nbsp;</span><span class='increase-col'>&nbsp;</span>");
		}
	});

	$('.increase-col').live('click', function(){
		var $col = $(this).closest('.edit-col');
		if($col.hasClass('col-25')) {
			$col.removeClass('col-25').addClass('col-33');
			$(this).before("<span class='reduce-col'>&nbsp;</span>");
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
			$(this).after("<span class='increase-col'>&nbsp;</span>");
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

	$('.main-widget-editor .new-html').live('click', function(){
		$('.editable-content').append("<div class='col col-33 html-col edit-col'><span class='move-col'>&nbsp;</span><span class='del-col'>X</span><span class='reduce-col'>&nbsp;</span><span class='increase-col'>&nbsp;</span><textarea></textarea></div>");
	});

	$('.content-box .new-html').live('click', function(){
		$(this).parent().before("<div class='col col-33 html-col edit-col'><span class='move-col'>&nbsp;</span><span class='del-col'>X</span><span class='reduce-col'>&nbsp;</span><span class='increase-col'>&nbsp;</span><textarea></textarea></div>");
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
		$('.move-col, .del-col, .increase-col, .reduce-col, .upload-form, .widget-col').remove();
		$('#text').val($('.editable-content').html());
	}

	/*$('.upload-form').live('submit', function(e){
		$('.cms-loader').fadeIn(200);
		e.preventDefault();
		var $form = $(this).closest('.upload-form'),
			file = $form.find( 'input[name="userfile"]' ).val(),
        	url = $form.attr( 'action' ) + "/" + slug;

        $.ajaxFileUpload({ 
        	url: url,
        	secureuri : false,
        	fileElementId : 'userfile',
        	dataType : 'json',
        	complete : function(data, status){
        		$form.siblings('.cms-loader').remove();
        		$('.cms-loader').fadeOut(200);
        		if(data.responseText.search("The image you are attempting to upload exceedes the maximum height or width.") === -1) {
	        		$form.append(data.responseText);
	        		$form.find('img').attr('alt', $form.find('input[name=alt]').val());
	        		$form.after("<div class='caption'><textarea/></div>");
	        		$form.replaceWith($form.find('img'));
	        		$('textarea').redactor();
	        	} else {
	        		$form.html(data.responseText);
	        	}
        	}
        });
	});*/