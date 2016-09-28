/*
*   MYNX Admin Theme
*   v1.1.3
*   29/09/2016
*/

var delCode = '<span class="del-col">X</span>',
	movCode = '<span class="move-col">&nbsp;</span>',
	editCode = '<span class="editable-col">&nbsp;</span>',
	reduceCode = '<span class="reduce-col">&nbsp;</span>',
	increaseCode = '<span class="increase-col">&nbsp;</span>',
	defaultHtmlColumn = "<div class='col col-33 html-col movable resizable edit-col redactor'><textarea></textarea></div>",
	widgetColumn = '<div class="widget-col col-33 new-col"><select><option value="new-html">Add rich text column</option></select><input type="button" class="button add-widget-button" value="Add"></div><div class="clearfix"></div>',
	$edit = $('.editable-content');

$('.raw').each(function () {
    $(this).html("<textarea>" + $(this).html() + "</textarea>");
    addControls($(this));
});

if ($('select[name="cat_drop"]').val() === "new") {
    $('.category-input').attr('disabled', false);
} else {
    $('.category-input').attr('disabled', true);
}

$('.editable-content, .editable-content .content-box').sortable({
    handle: '.move-col'
});

$('.widget').each(function () {
    addControls($(this));
});

$('.text-data').each(function () {
    var data = $(this).html();
    $(this).html('<input type="text" value="' + data + '"/>');
});

$edit.find('.content-box').each(function () {
    $(this).append(widgetColumn);
});

$edit.find('.html-col').each(function () {
    var $this = $(this);
    $this.html("<textarea>" + $(this).html() + "</textarea>");
    $this.addClass('edit-col');
    addControls($this);
});

$edit.find('.content-box').each(function () {
    //addControls($(this));
});

$edit.find('.col-content').each(function () {
    var $this = $(this);
    $this.addClass('edit-col');
    addControls($this.closest('.col'));
});

for (var widget in widgetCode) {
    var additionCode = "<option value='" + widget + "'>" + widgetCode[widget].text + "</option>";
    $('.widget-col select').append(additionCode);
}

for (var optionWidget in optionWidgetCode) {
    var optionsAdditionCode = "<div class='clear'></div><label for='" + optionWidget + "'>" + optionWidgetCode[optionWidget].text + "</label>" + optionWidgetCode[optionWidget].code;
    $('.page-options').append(optionsAdditionCode);
}

$('.show-page-options').click(function () {
    $('.page-options').slideToggle();
});

$('.increase-col').live('click', function () {
    var $col = $(this).closest('.edit-col');
    if ($col.hasClass('col-25')) {
        $col.removeClass('col-25').addClass('col-33');
        $(this).before(reduceCode);
    } else if ($col.hasClass('col-33')) {
        $col.removeClass('col-33').addClass('col-50');
    } else if ($col.closest('.edit-col').hasClass('col-50')) {
        $col.removeClass('col-50').addClass('col-66');
    } else if ($col.closest('.edit-col').hasClass('col-66')) {
        $col.removeClass('col-66').addClass('col-75');
    } else if ($col.closest('.edit-col').hasClass('col-75')) {
        $col.removeClass('col-75').addClass('col-100');
        $(this).remove();
    }
});

$('.reduce-col').live('click', function () {
    var $col = $(this).closest('.edit-col');
    if ($col.hasClass('col-100')) {
        $col.removeClass('col-100').addClass('col-75');
        $(this).after(increaseCode);
    } else if ($col.closest('.edit-col').hasClass('col-75')) {
        $col.removeClass('col-75').addClass('col-66');
    } else if ($col.closest('.edit-col').hasClass('col-66')) {
        $col.removeClass('col-66').addClass('col-50');
    } else if ($col.closest('.edit-col').hasClass('col-50')) {
        $col.removeClass('col-50').addClass('col-33');
    } else if ($col.closest('.edit-col').hasClass('col-33')) {
        $col.removeClass('col-33').addClass('col-25');
        $(this).remove();
    }
});

$('.del-col').live('click', function () {
    var $col = $(this).closest('.edit-col');
    if (confirm('Delete this column?')) $col.remove();
});

$('select[name="cat_drop"]').live('change', function () {
    if ($(this).val() === "new") {
        $('.category-input').attr('disabled', false);
    } else {
        $('.category-input').attr('disabled', true);
    }
});


$('.editable-col').live('click', function () {
    if ($(this).closest('.edit-col').find('.upload-form')) {
        alert('Please upload an image first');
        return false;
    }
    var $col = $(this).siblings('.col-content'),
		html = $col.html();
    $col.html('<textarea>' + html + '</textarea>');
    $(this).removeClass('editable-col').addClass('revert-col');
});

$('.revert-col').live('click', function () {
    var $textarea = $(this).siblings('.col-content').find('textarea');
    $textarea.replaceWith($textarea.val());
    $(this).removeClass('revert-col').addClass('editable-col');
});

$('.cms-header input').live('keyup', function(){
	var title = $('.cms-header input').val();
	var slug = title.toLowerCase().replace(/ /g, "-");
	$('#slug').val(slug);
});


$('.add-widget-button').live('click', function () {
    var $data, contentBox = false;
    if ($(this).siblings('select').val() === "new-content-box") {
        $data = '<div class="content-box resizable movable edit-col col col-100"><div class="clearfix"></div><div class="widget-col col-33 new-col"><select><option value="new-html">Add rich text column</option>';
        var additionCode = "";
        for (var widget in widgetCode) {
            additionCode += "<option value='" + widget + "'>" + widgetCode[widget].text + "</option>";
        }
        $data += additionCode;
        $data += '</select><input type="button" class="button add-widget-button" value="Add" /></div><div class="clearfix"></div></div>';
        contentBox = true;
    } else if ($(this).siblings('select').val() === "new-html") {
        $data = addControls($(defaultHtmlColumn));
        if ($(this).parent().hasClass('main-widget-editor')) {
            $edit.append($data);
        } else {
            $(this).parent().before($data);
        }
        $('.redactor textarea').redactor();
        //$('.redactor textarea').removeClass('newtextarea');
    } else {
        $data = $(widgetCode[$(this).siblings('select').val()].code);
        $data = addControls($data);
    }

    if ($(this).parent().hasClass('main-widget-editor')) {
        $edit.append($data);
    } else {
        $(this).parent().before($data);
    }
    if (contentBox) addControls($($('.content-box')[$('.content-box').length - 1]));
});

blockEditor();
$('.block-sidebar, .block-toolbar, .block-footer').click(function () {
    $checkbox = $(this).find('input');
    $checkbox.attr('checked', !$checkbox.attr('checked'));
    blockEditor();
});

$('.settings_form').submit(function () {
    $(this).find('textarea').attr('disabled', false);
});

$('.upload-image').live('click', function () {
    $('.image-library').after('<iframe class="upload-form refresh" src="/admin/upload"></iframe>');
});

$('.delete-link').click(function () {
    if (confirm('Are you sure you want to delete?')) window.location = "/admin/delete/" + $(this).data('del');
});

$(window).load(function () {
    $('.image-library').masonry({
        itemSelector: '.edit-image'
    });
});

function rasterizeContent() {
    for (func in preRasterize) {
        preRasterize[func]();
    }

    $('.redactor_box').each(function () {
        $(this).replaceWith($(this).find('textarea').val());
    });

    $('textarea').each(function () {
        $(this).replaceWith($(this).val());
    });

    $('.content-widget').each(function () {
        var wc = "/@/" + $(this).data("name") + "/~/";
        $(this).find('input, select, textarea').each(function () {
            wc += "@" + $(this).data("paramname") + "==" + $(this).val();
        });
        wc += "/@/";
        $(this).html(wc);
    });

    $('.text-data input').each(function () {
        $(this).replaceWith($(this).val());
    });

    $('.move-col, .del-col, .increase-col, .reduce-col, .upload-form, .widget-col, .editable-col, .revert-col').remove();
    $('#text').val($('.editable-content').html());
    for (func in postRasterize) {
        postRasterize[func]();
    }
}

function addControls($this) {
    if ($this.hasClass('movable')) { $this.prepend(movCode); }
    if ($this.hasClass('editable')) { $this.prepend(editCode); }
    $this.prepend(delCode);
    if ($this.hasClass('resizable')) {
        if (!$this.hasClass('col-25')) {
            $this.prepend(reduceCode);
        }
        if (!$this.hasClass('col-100')) {
            $this.prepend(increaseCode);
        }
    }
    return $this;
}

function blockEditor() {
    if ($('.block-sidebar input:checked').length === 0) {
        $('.sidebar-code').attr('disabled', true);
    } else {
        $('.sidebar-code').attr('disabled', false);
    }

    if ($('.block-toolbar input:checked').length === 0) {
        $('.toolbar-code').attr('disabled', true);
    } else {
        $('.toolbar-code').attr('disabled', false);
    }

    if ($('.block-footer input:checked').length === 0) {
        $('.footer-code').attr('disabled', true);
    } else {
        $('.footer-code').attr('disabled', false);
    }
}