jQuery(document).ready(function() {
		
	jQuery(".menu-trigger").click(function() {
		
		jQuery(".nav").slideToggle(400, function() {
			jQuery(this).toggleClass("nav-expanded").css('display', '');
		});
		
	});
	
	jQuery(".side-trigger").click(function() {
		
		jQuery(".side").slideToggle(400, function() {
			jQuery(this).toggleClass("side-expanded").css('display', '');
		});
		
	});
	
});