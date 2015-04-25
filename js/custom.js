	$(document).ready(function(){
		$(".language").hide(); // Hide all tab conten divs by default
		$(".language:first").show(); // Show the first div of tab content by default
		
		$(".language a").click(function(){ //Fire the click event
			var activeTab = $(this).attr("href"); // Catch the click link
			$(".language a").removeClass("active"); // Remove pre-highlighted link
			$(this).addClass("active"); // set clicked link to highlight state
			$(activeTab).fadeIn(); // show the target tab content div by matching clicked link.
		});

		var h = $('#loguser').height() + 10;
		var w = $('#loguser').width();
		$('#info').css({
		    position: 'relative',
		    top: h,
		    left: -w
		});

		$('#info').hide();
		$('#logined').mouseover(function (event)
		{
		    $('#info').show();
		});
		$('#info').mouseleave(function (event)
		{
		    $('#info').hide();
		});

		$("#sss").click(function ()
		{
		    var str = $("#content").val();
		    if (str != "undefined")
		    {
		        $("#sss")[0].href = "search.aspx";
		    }
		    else
		    {
		        $("#sss")[0].href = "search.aspx?" + str;
		    }
		    
		});
		$(".xuanfu").click(function (event) {
            
		    if ($(".xuanfu2").is(":hidden"))
		        $(".xuanfu2").show();
		    else
		        $(".xuanfu2").hide();
		}
        );

  
		document.onkeydown = function (event)
		{
		    var e = event || window.event || arguments.callee.caller.arguments[0];
		    if (e && e.keyCode == 27)
		    { // 按 Esc 
		        //要做的事情
		    }
		    if (e && e.keyCode == 113)
		    { // 按 F2 
		        //要做的事情
		    }
		    if (e && e.keyCode == 13)
		    { // enter 键
		        if (e && e.keyCode == 13 && $("#searchtb").is(":focus")) {
                    
		            $("#searchtb").click();
		        }
		        else if ($(".search input[type='text']").is(":focus"))
		        {
		            setTimeout(function(){location.href = "search.aspx?" + $(".search input[type='text']").val();},10);
		        }

		       
		    }
		}

		$('.imgclick').click(function ()
		{
		    if (($(this).data("had")))
		    {
		        alert("just one");
		        return;
		    }
		    $(this).data("had", 1);
		   
		   $(this).next().html(parseInt($(this).next().html()) + 1);
		   $.post("ajax.aspx?key=dianzan&" + $(this).data("which") + "&" + $(this).data("id"),
            {
            },
            function (data, status)
            {
                if (status == "success")
                {
                    if (data != "")
                    {
                        alert(data);
                        if (data == "noaccess")
                        {
                            window.location.href = "login.aspx";
                        }
                    }
                }
                else
                {
                    alert("ajax出现错误; 请反馈~~~");
                }
            });
		    
		});

	});

	function lookbigimg(obj)
	{
	    if (obj.style.width == "200px")
	        obj.style.width = "";
	    else
	        obj.style.width = "200px";
	   // obj.style.width = "";
        
	}


    