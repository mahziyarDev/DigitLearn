$(document).ready(function () {
    // تاگل زیرمنو
    $('.menu-item-parent').click(function (e) {
        e.stopPropagation();
        $(this).parent().toggleClass('open');
    });

    // کلیک روی آیتم ساده
    $('.menu-item-single').click(function () {
        $('.menu-item-single').removeClass('active');
        $(this).addClass('active');
        var menuText = $(this).find('span').text().trim();
        console.log('Clicked: ' + menuText);
    });

    // کلیک روی زیرمنو
    $('.submenu li').click(function () {
        $('.submenu li').removeClass('active');
        $(this).addClass('active');
        var submenuText = $(this).clone().find('i').remove().end().text().trim();
        console.log('Submenu clicked: ' + submenuText);
    });
});