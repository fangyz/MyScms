
$(document).ready(function () {
    for (let i = 0; i < $('.item1').length; i++) {
        if ($('.item1_item2')[i].children.length == 0) {
            $('.item1')[i].children[2].className = 'item1_img'
        }
    }

    //遍历一级标题，如果二级标题为空则不显示图标
    $('.item1').click(
        function (val) {
            console.log($(this).children()[1].innerText);//点击一级标题，打印点击的栏目
            $('.content').html($(this).children()[1].innerText);//在内容页显示点击的按钮文字
            if ($(this).next().is(":hidden")) {//如果二级导航没打开，打开它
                $(this).next().show(500);
                $(this).children('.you').css('transform', 'rotate(90deg)');//图片旋转90度
            }
            else if ($(this).next().children().length == 0) { }//如果没有二级导航，没操作
            else {//如果二级导航打开了，关闭它
                $(this).next().hide(500)
                $('.you').css('transform', 'rotate(0deg)');//图片回到原来样子
            }
        }
    );

    //$('.item2').click(//带你就二级标题触发事件
    //    function (val) {
    //        console.log($(this).children()[0].innerText);
    //        $('.content').html($(this).children()[0].innerText);
    //    }
    //)

    //设置菜单栏点击请求
    $("#item_search").bind("click", function () {

    });


    //$(document).ready(function () {
    //    $("#searchBtn").click(function () {
    //        $.ajax({
    //            type: "GET",
    //            url: " https://api.passport.xxx.com/checkNickname?username=" + mylogin.username + "&token=" + mylogin.token + "&nickname=" + nickname + "&format=jsonp&cb=?",
    //            dataType: "json",
    //            success: function (data) {
    //                if (data.errorCode == 0) {
    //                    $("#nickname").val(mylogin.nickname);
    //                } else {
    //                    $("#nickname").val("用户");
    //                }
    //            },
    //            error: function (jqXHR) {
    //                console.log("Error: " + jqXHR.status);
    //            }
    //        });
    //    });
    //});

    //function dologin(qrid, username, token) {
    //    $.ajax({
    //        url: "http://api.passport.pptv.com/v3/login/qrcode.do",
    //        type: "post",
    //        dataType: "jsonp",
    //        data: { from: "clt", qrid: qrid, username: username, token: token },
    //        success: function (data) {
    //            try {
    //                var p = external.GetObject('@xxx.com/passport;1');
    //                p.On3rdLogin2(0, 0, data, true);
    //            } catch (e) {
    //                return false;
    //            }
    //            setTimeout(function () {
    //                try {
    //                    var wb = external.Get('Signin2Window');
    //                    wb.OnClose();
    //                } catch (e) {
    //                }
    //            }, 200);
    //        }
    //    });
    //}

})