function runbanner(w, h){
    var $slider = $(".slider123");
    $slider.slideshow({
        width        : w,
        height       : h,
        pauseOnHover : false,
        transition :['barLeft', 'barRight'], 
        delay    :3000,                 /* Thời gian chạy hiệu ứng thay đổi hình ảnh  1000 tương ứng vói 1s*/
    });
}