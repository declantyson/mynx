imageslider = {
    c: 0,
    l: $('.slideshow-item').length
}

$(document).ready(function () {
    $(window).load(function () {
        slideshowSize();
        setTimeout(function () { slide(1, 5000) }, 5000)
    });
    $(window).resize(function () {
        slideshowSize();
    });
});

function slideshowSize() {
    console.log($('.slideshow').width());
    $('.slideshow-item').css({
        width: $('.slideshow').width()
    });
    $('.slideshow-wrapper').width($('.slideshow-item').width() * imageslider.l);
}

function slide(dir, timeout) {
    clearTimeout(imageslider.t);
    
    if (dir === 1 && imageslider.c + 1 === imageslider.l) {
        imageslider.c = -1;
    } else if (dir === -1 && imageslider.c - 1 === -1) {
        imageslider.c = imageslider.l;
    }

    $('.slideshow-item').animate({
        left: -((imageslider.c + dir) * $('.slideshow-item').width())
    }, 1000);

    imageslider.c += dir;
    imageslider.t = setTimeout(function () { slide(1, 5000) }, timeout);
}