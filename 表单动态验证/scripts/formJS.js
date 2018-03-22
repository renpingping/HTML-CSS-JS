//表单提交时触发表单的onsubmit事件
/*$(function(){
	$("#registrationForm").submit(function(event){
		//alert("Form submitted.");
		event.preventDefault();
	});
	//判断必填字段是否填入
	//文本框判断
	$("#registrationForm").submit(function(event){
		if(!$(this.name).val()){
			$(this.name).parents("div.required").addClass("error");
			event.preventDefault();
			//alert("You must enter a name.");
		}
	//单选按钮判断
		if(!$(this).find("input[name='gender']:checked").length){
			$("input[name='gender']",this).parents("div.required").addClass("error");
			event.preventDefault();
			//alert("You must select your gender.");
		}
	});

});*/
$(function(){

	$("#registrationForm").submit(function (event){

		var errors = [];
		if(!$(this.name).val()){
			errors.push("<li>You must enter a name.</li>");
			$(this.name).parents("div.required").addClass("error");
			event.preventDefault();
		}
		if(!$("input[name='gender']:checked",this).length){
			errors.push("<li>You must select a gender.</li>");
			$("input[name='gender']",this).parents("div.required").addClass("error");
			event.preventDefault();
		}
		$("div.errors",this).remove();
		if(errors.length > 0){
			$(this).prepend("<div class='errors'>You must "+"correct the following errors:<ul>"+ errors.join("")+"</ul></div>");
		}

	});

});

