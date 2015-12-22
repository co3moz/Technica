/*
 *Bushido HTML5 E-Commerce Template v1.1
 *Copyright 2014 8Guild.com
 *Scripts for Bushido Coming Soon Page
 */

/*Document Ready*/////////////////
$(document).ready(function(e) {
	
	/*Countdown
	*******************************************/
	$('#timer').countdown('2015/01/15', function(event) {
    $(this).html(event.strftime('%D:%H:%M:%S'));
  });
	
	/*Features Tabs
	*******************************************/
	var $featureTab = $('.feature-tabs .tab');
	var $featureTabPane = $('.feature-tabs .tabs-pane');
	$featureTab.on('mouseover', function(){
		$featureTab.removeClass('active');
		$(this).addClass('active');
		var $curTab = $(this).attr('data-tab');
		$featureTabPane.removeClass('current');
		$('.feature-tabs .tabs-pane' + $curTab).addClass('current');
	});
	
	/*Subscription Form Widget
	*******************************************/
	var $subscrForm = $('.subscr-form');
	var $nextField = $('.subscr-next');
	$subscrForm.validate();
	$nextField.click(function(e){
		var $target = $(this).parent();
			if($subscrForm.valid() === true){
				$target.hide('drop', 300, function(){
					$target.next().show('drop', 300);
				});
			}
		e.preventDefault();
	});
	
	/*Adding Placeholder Support in Older Browsers
	************************************************/
	$('input, textarea').placeholder();
	
});