//点击链接时，弹出提示框
$(document).ready(function(){     
	$("a").click(function(event){
		alert("You clicked on a link to " + this.href );
	});
});
			/*
			//可简化为
			$(function(){
				$("a").click(function(event){
					alert("You clicked on a link to " + this.href );
				});
			});
			//原生JS代码
			window.addEventListener ('load', function(){
				var links = document.getElementsByTagName("a");
				for (var i = 0; i < links.length; i++){
					links[i].addEventListener('click',function(){
						alert("You clicked on a link to " + this.href);
					});
				}
			});
			*/
//判断打开的链接是本地链接还是外部链接，
//外部链接打开一个新窗口，并禁用默认行为。
$(function (){
	$("a").click(function(event){
		if (null != this.href && this.href.length > 4 && this.href.substring(0,4) == "http"){
			event.preventDefault();  //禁用默认行为
			window.open(this.href);
		}
	})
});
			/*
			$(function(){
				$("#open").hide();
				$("#open, #closed").click(function(event){
					$("#open,#closed").toggle();         
					//toggle()方法：用于显示当前隐藏元素，隐藏当前显示元素。
				});
			});
			*/
//指定id添加样式
$(function(){
	$("#open,#closed").click(function (event ){
		$(this).css("text-decoration","underline");
	alert("The font size is" + $(this).css("font-size"));
	});
});
//鼠标移动时改变元素外观。
//移入时添加给<p>添加类名，移开时删除类。
$(function(){
	$("p").mouseenter(function(){
		$(this).addClass("highlighted");
	});
	$("p").mouseleave(function(){
		$(this).removeClass("highlighted");
	});
});

//使元素在是否归属于highlighted类之间切换
$(function(){
	$("li").click(function(){
		$(this).toggleClass("highlighted");
	});
});
/*
//首次点击时加入highlighted类，再次点击弹出提醒框
//使用hasClass()来判断元素是否已归属于指定类
$(function(){
	$("li").click(function(){
		if(!$(this).hasClass("highlighted")){
			$(this).addClass("highlighted");
		}
		else{
			alert("This is item is already highlighted.");
		}
	})
});
*/
//val()可用于获取和修改表单字段的值
$(function(){
	//获得焦点后，如果是文本框内是示例文字，则清空，再输入的文字，颜色为黑色。
	$("input[name='email']").focus(function(){      //这里的属性选择器[name='email']，区分双引号和单引号
		if ($(this).val() == "person@example.com"){
			$(this).val("");
			$(this).css("color","black");
		}
	});

	//离开属性为email的input标签时，若文本框为空，则显示示例文字
	//若用户离开时输入了值，就将提交按钮的属性disabled删除
	//若没有输入任何值，就添加属性disabled，以防之前将该属性删除了
	$("input[name='email']").blur(function(){
		if ($(this).val() == ""){
			$(this).val("person@example.com");
			$(this).css("color","#999");
			$("#emailFormSubmit").attr("disabled","disabled");
		}
		else{
			$("#emailFormSubmit").removeAttr("disabled");
		}
	});
});
