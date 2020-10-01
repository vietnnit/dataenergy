//--- Toggle --//
//    function toggleDiv(divId) {
//        $("#" + divId).toggle();
//    }
//    function toggleDiv1(divId1, divId2, divId3, divId4) {
//        $("#" + divId1).toggle();
//        $("#" + divId2).hide();
//        $("#" + divId3).hide();
//        $("#" + divId4).hide();
//    }

//-- Tooltip text box --//

//    $(document).ready(function () {
//        $('input#txtgrey1').gips(
//            { 'theme': 'grey',
//                autoHide: true,
//                pause:1000,
//                placement: 'bottom',
//                text: 'Nhập từ khoá: <b>Số Hiệu</b>, <b>Tiêu đề</b> hoặc <b>Nội dung ngắn gọn</b> của Văn Bản...'
//            });
//        $('input#txtgrey2').gips(
//            { 'theme': 'grey',
//                autoHide: true,
//                pause:1000,
//                placement: 'bottom',
//                text: 'Nhập từ khoá: <b>Số Hiệu</b>, <b>Tiêu đề</b> hoặc <b>Nội dung ngắn gọn</b> của công văn...'
//            });
//        $('input#txtgrey3').gips(
//            { 'theme': 'grey',
//                autoHide: true,
//                pause:1000,
//                placement: 'bottom',
//                text: 'Nhập từ khoá: <b>Số Hiệu</b>, <b>Tiêu đề</b> hoặc <b>Nội dung ngắn gọn</b> của tiêu chuẩn việt nam...'
//            });
//        $('input#txtgrey4').gips(
//            { 'theme': 'grey',
//                autoHide: true,
//                pause:1000,
//                placement: 'bottom',
//                text: 'Nhập từ khoá: <b>Số Hiệu</b>, <b>Tiêu đề</b> hoặc <b>Nội dung ngắn gọn</b> của thủ tục hành chính...'
//            });
//    });

// MenuBar //

//    ddsmoothmenu.init({
//        mainmenuid: "dd-menubar",
//        orientation: 'h',
//        classname: 'ddsmoothmenu',
//        //customtheme: ["#1c5a80", "#18374a"],
//        contentsource: "markup"
//    })

//Slider Caroul //

//    $(function () {
//        $("#foo1").carouFredSel({
//            items: 3,
//            scroll: 3,
//            circular: true,
//            infinite: false,
//            auto: {
//                play            : true,
//                duration        : 1000  
//            },
//            height: 160,
//            prev: {
//                button: "#foo1_prev",
//                key: "left"
//            },
//            next: {
//                button: "#foo1_next",
//                key: "right"
//            },
//            pagination: "#foo1_pag"
//        });
//        
//        $("#truong_slider").carouFredSel({
//            items: 3,
//            scroll: 3,
//            circular: true,
//            infinite: false,
//            auto: {
//                play            : true,
//                duration        : 1000  
//            },
//            height: 160,
//            prev: {
//                button: "#truong_prev",
//                key: "left"
//            },
//            next: {
//                button: "#truong_next",
//                key: "right"
//            },
//            pagination: "#truong_pag"
//        });


//        $("#adv-carousel").carouFredSel({
//            items: 5,
//            scroll: 1,
//            circular: true,
//            infinite: false,
//            auto: {
//                play            : true,
//                duration        : 1000  
//            },
//            height: 60,
//            prev: {
//                button: "#adv-prev",
//                key: "left"
//            },
//            next: {
//                button: "#adv-next",
//                key: "right"
//            },

//        });
//        

//        $("#newsStrID-carousel").carouFredSel({
//            items: 5,
//            scroll:1,

//            circular: true,
//            infinite: false,
//            direction: 'up',
//            auto: {
//                play            : true,
//                duration        : 1000  
//            },
//            height: 355,
//            width:234,
//            
//            prev: {
//                button: "#newsStrID-prev",
//                key: "up"
//            },
//            next: {
//                button: "#newsStrID-next",
//                key: "down"
//            }

//        });


//    });

// Slider Hotnews //
//    $(function () {
//        $('#bxslider_hotnews').anythingSlider({
//            easing: "linear",
//            autoPlay: true,
//            delay: 5000,
//            resumeDelay: 25000,
//            animationTime: 600,
//            hashTags: false,
//            pauseOnHover: true,
//            stopAtEnd: false
//        });
//    });



//Flex

//        var g_currMenu = null;
//        var g_TimerID = 0;

//        function GetBrowserWindowSize() {
//            var myWidth = 0, myHeight = 0;
//            if (typeof (window.innerWidth) == 'number') {
//                myWidth = window.innerWidth;
//                myHeight = window.innerHeight;
//            } else if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
//                myWidth = document.documentElement.clientWidth;
//                myHeight = document.documentElement.clientHeight;
//            } else if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
//                myWidth = document.body.clientWidth;
//                myHeight = document.body.clientHeight;
//            }
//            return { width: myWidth, height: myHeight };
//        }

//        function GetElementSize(element) {
//            var result = new Object();
//            result.width = 0;
//            result.height = 0;
//            if (element.offsetWidth && element.offsetHeight) {
//                result.width = element.offsetWidth;
//                result.height = element.offsetHeight;
//            }
//            else if (element.style && element.style.pixelWidth && element.style.pixelHeight) {
//                result.width = element.style.pixelWidth;
//                result.height = element.style.pixelHeight;
//            }
//            return result;
//        }

//        function GetPosition(node) {
//            var pos = new Array(0, 0);
//            if (node.offsetParent) {
//                while (node.offsetParent) {
//                    pos[0] += node.offsetLeft;
//                    pos[1] += node.offsetTop;
//                    node = node.offsetParent;
//                    if (node == document.body) {
//                        pos[0] -= node.offsetLeft;
//                        pos[1] -= node.offsetTop;
//                    }
//                }
//            }
//            return pos;
//        }

//        function DoPopup(objid, pnlid) {
//            var obj = document.getElementById(objid);
//            var popup = document.getElementById(pnlid);
//            popup.target = obj;
//            obj.className = 'sel';

//            var p = GetPosition(obj);

//            var br = GetBrowserWindowSize();
//            var sz = GetElementSize(popup);

//            var left = p[0];
//            var top = p[1] + parseInt(obj.offsetHeight);
//            if (left + sz.width > br.width) {
//                left = br.width - sz.width;
//            }

//            popup.style.display = 'block';
//            popup.style.top = 20 + "px";
//            /*popup.style.top = 25 + top+ "px";*/
//            /*popup.style.left = -76 + left + "px";*/

//            if (g_currMenu != null)
//                HidePopup(g_currMenu);

//            g_currMenu = pnlid;
//        }

//        function KillPopup(pnlid) {
//            g_TimerID = setTimeout('HidePopup("' + pnlid + '")', 200);
//        }

//        function KillTimer() {
//            if (g_TimerID != 0) clearTimeout(g_TimerID);
//            g_TimerID = 0;
//        }

//        function HidePopup(pnlid) {
//            var popup = document.getElementById(pnlid);

//            popup.style.display = 'none';

//            g_currMenu = null;

//            var obj = popup.target;
//            obj.className = '';
//        }


//Go top //

$(document).ready(function () {

    // hide #back-top first
    $("#back-top").hide();

    // fade in #back-top
    $(function () {
        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('#back-top').fadeIn();
            } else {
                $('#back-top').fadeOut();
            }
        });

        // scroll body to 0px on click
        $('#back-top a').click(function () {
            $('body,html').animate({
                scrollTop: 0
            }, 800);
            return false;
        });
    });

});

//Datetime

//        $(function () {
//            $("#projected_start_day").datepicker({ dateFormat: "dd/mm/yy" }).val()
//            $("#projected_end_day").datepicker({ dateFormat: "dd/mm/yy" }).val()

//        });  

//Scrollbar

//        (function($){
//			$(window).load(function(){
//				$("#content_comment").mCustomScrollbar({
//					set_width:false, /*optional element width: boolean, pixels, percentage*/
//					set_height:false, /*optional element height: boolean, pixels, percentage*/
//					horizontalScroll:false, /*scroll horizontally: boolean*/
//					scrollInertia:550, /*scrolling inertia: integer (milliseconds)*/
//					scrollEasing:"easeOutCirc", /*scrolling easing: string*/
//					mouseWheel:"auto", /*mousewheel support and velocity: boolean, "auto", integer*/
//					autoDraggerLength:true, /*auto-adjust scrollbar dragger length: boolean*/
//					scrollButtons:{ /*scroll buttons*/
//						enable:false, /*scroll buttons support: boolean*/
//						scrollType:"continuous", /*scroll buttons scrolling type: "continuous", "pixels"*/
//						scrollSpeed:20, /*scroll buttons continuous scrolling speed: integer*/
//						scrollAmount:40 /*scroll buttons pixels scroll amount: integer (pixels)*/
//					},
//					advanced:{
//						updateOnBrowserResize:true, /*update scrollbars on browser resize (for layouts based on percentages): boolean*/
//						updateOnContentResize:false, /*auto-update scrollbars on content resize (for dynamic content): boolean*/
//						autoExpandHorizontalScroll:false /*auto expand width for horizontal scrolling: boolean*/
//					},
//					callbacks:{
//						onScroll:function(){}, /*user custom callback function on scroll event*/
//						onTotalScroll:function(){}, /*user custom callback function on bottom reached event*/
//						onTotalScrollOffset:0 /*bottom reached offset: integer (pixels)*/
//					}
//				});
//			});
//		})(jQuery);   

//Popup


var slideTime = 500;
var floatAtBottom = false;
function floating_init() {

    winOnResize(); // set initial position
    xAddEventListener(window, 'resize', winOnResize, false);
    xAddEventListener(window, 'scroll', winOnScroll, false);
}
function winOnResize() {
    checkScreenWidth();
    winOnScroll(); // initial slide
}
function winOnScroll() {
    var y = xScrollTop();
    if (floatAtBottom) {
        y += xClientHeight() - xHeight('light');
    }
    xSlideTo('light', (screen.width) / 2 - 330, y + 25, slideTime);

}
function checkScreenWidth() {
    if (screen.width <= 800) {
        document.getElementById('light').style.display = 'none';

    }
}


function LoadFlash() {
    if (document.getElementById("Oload") != null)
        if (document.getElementById("Oload").value == 1) {
            document.getElementById('light').style.display = 'block';
            document.getElementById('fade').style.display = 'block'
        }
        else {
            return;
        }
    else return;
    floating_init();
}



function floating_init_register() {

    winOnResize_register(); // set initial position
    xAddEventListener(window, 'resize', winOnResize_register, false);
    xAddEventListener(window, 'scroll', winOnScroll_register, false);
}
function winOnResize_register() {
    checkScreenWidth_register();
    winOnScroll_register(); // initial slide
}
function winOnScroll_register() {
    var y = xScrollTop();
    if (floatAtBottom) {
        y += xClientHeight() - xHeight('light_register');
    }
    xSlideTo('light_register', (screen.width) / 2 - 430, y + 25, slideTime);

}
function checkScreenWidth_register() {
    if (screen.width <= 800) {
        document.getElementById('light_register').style.display = 'none';

    }
}


function LoadFlash_register() {

    document.getElementById('light_register').style.display = 'block';
    document.getElementById('fade_register').style.display = 'block';
    floating_init_register();

}


function floating_init1() {
    winOnResize1(); // set initial position
    xAddEventListener(window, 'resize', winOnResize1, false);
    xAddEventListener(window, 'scroll', winOnScroll1, false);
}
function winOnResize1() {
    checkScreenWidth1();
    winOnScroll1(); // initial slide
}
function winOnScroll1() {
    var y = xScrollTop();
    if (floatAtBottom) {
        y += xClientHeight() - xHeight('light1');
    }
    xSlideTo('light1', (screen.width) / 2 - 330, y + 25, slideTime);

}
function checkScreenWidth1() {
    if (screen.width <= 800) {
        document.getElementById('light1').style.display = 'none';

    }
}


function LoadFlash1() {
    document.getElementById('light1').style.display = 'block';
    document.getElementById('fade1').style.display = 'block';
    floating_init1();
}


//            $(document).ready(function() {
//				$('#tabdetail_sticky1').stickyScroll({ container: '#content_sticky' });
//                $('.box-detail-vanban-col2').stickyScroll({ container: '#content_sticky'});
//                $('#adv_sticky1').stickyScroll({ container: '#main_content_sticky' });
//		});

$(function () {
    var zIndexNumber = 5000;
    // Put your target element(s) in the selector below!
    $("div").each(function () {
        $(this).css('zIndex', zIndexNumber);
        zIndexNumber -= 10;
    });
});
  