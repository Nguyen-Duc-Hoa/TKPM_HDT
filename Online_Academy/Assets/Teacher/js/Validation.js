$(function () {
	$(document).ready(function () {

	$("#upload").validate( {
		
		//onfocusout: false,
		onkeyup: false,
		//onclick: false,
		rules: {
			price: {
				min: 0,
				max: 100000,
				digits:true
			},
			discount: {
				min: 0,
				max: 100,
				digits: true
			},
			namecourse: {
				remote: {
					url: '/TeacherCourses/CheckNameCourse',
					type: "post",
					data: {
						name: function () {
							return $('#namecourse').val();
						}
					}
                }
					
			},
			name: {
				remote: {
					url: '/TeacherCourses/CheckNameCourseEdit',
					type: "post",
					data: {
						name: function () {
							return $('#namecourse').val();
						},
						idcourse: function () {
							return $('#id').val();
						},
					}
				}

			}
			
		},
		messages: {
			price: {
				max: "Please enter price less 100000"
				
			},
			discount: {
				max: "Please enter discount less than or equal to 100"
				
			},
			namecourse: {
				
				remote:  jQuery.validator.format("Course name is already")
				

			},
			name: {

				remote: jQuery.validator.format("Course name is already")


			}
			
		}
	});
		//jQuery.extend(jQuery.validator.messages, {
			
		//	remote: 'Course name is already'
		//});
	});
});