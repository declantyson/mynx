imageslider = {
    c: 0,
    l: $('.slideshow-item').length,
    iw : $('.slideshow-item').outerWidth()
}

$(document).ready(function () {
    $('img').load(function () {
        slideshowSize();
    });
    $(window).load(function () {
        setTimeout(function () { slide(1, 5000) }, 5000)
    });
    $(window).resize(function () {
        slideshowSize();
    });

    $('.right-arrow').click(function () {
        slide(1, 10000);
    });

    $('.left-arrow').click(function () {
        slide(-1, 10000);
    });
});

function slideshowSize() {
    $('.slideshow-item').css({
        width: $('.slideshow').width()
    });
    $('.slideshow-wrapper').width($('.slideshow-item').width() * imageslider.l);
    imageslider.iw = $('.slideshow-item').outerWidth();
}

function slide(dir, timeout) {
    clearTimeout(imageslider.t);
    
    if (dir === 1 && imageslider.c + 1 === imageslider.l) {
        imageslider.c = -1;
    } else if (dir === -1 && imageslider.c - 1 === -1) {
        imageslider.c = imageslider.l;
    }

    $('.slideshow-item').animate({
        left: -((imageslider.c + dir) * imageslider.iw)
    }, 1000);

    imageslider.c += dir;
    imageslider.t = setTimeout(function () { slide(1, 5000) }, timeout);
}