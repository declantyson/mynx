function prettyTransition(){
	if(window.location.hash.substring(1) === "") window.location.hash = 'home';

	if(Modernizr.csstransitions) {
		$('.content').css({
			left : '-50px',
			opacity : 0
		});			
		$('.sidebar').css({
			top : '-50px',
			opacity : 0
		});

		var bg_options = {
			opacity : 1
		};
		bg_options[params.bgimgposhorizontal] = '-33%';
		bg_options[params.bgimgposvertical] = 0;
		$('.bg-img').css(bg_options);

		$('h1').css({
			opacity : 0
		});
	}

	setTimeout(function(){
		$.ajax({
			url: '/themes/ajaxy/page.aspx?slug=' + window.location.hash.substr(1),
			type: 'GET'
		}).done(function(data){
			$('.slide').css({
				// opacity : 0,
				'background-image' : 'url(/themes/ajaxy/images/ajax-loader.gif)'
			});

			$('.slide').html(data);

			$('.content').css({
				left : '-50px',
				opacity : 0
			});			
			$('.sidebar').css({
				top : '-50px',
				opacity : 0
			});
			var bg_options = {
				opacity : 1
			};
			bg_options[params.bgimgposhorizontal] = '-33%';
			bg_options[params.bgimgposvertical] = 0;
			$('.bg-img').css(bg_options);
			$('h1').css({
				opacity : 0
			});

			setTimeout(function(){
				$('body').css({
					'background-color' : params.bgcolor
				});

				$('.slide').css({
					opacity : 1,
					'background-image' : 'none'
				});

				$('.content').css({
					left : 'auto',
					opacity : 1
				});			
				$('.sidebar').css({
					top : 'auto',
					opacity : 1
				});

				var bg_options = {
					opacity : 1
				};
				bg_options[params.bgimgposhorizontal] = 0;
				bg_options[params.bgimgposvertical] = 0;
				$('.bg-img').css(bg_options);

				$('h1').css({
					opacity : 1
				});
			}, 1000);

		});
	}, 1000);
}

$(document).ready(function(){
	prettyTransition();
	$(window).on('hashchange', function (){
		prettyTransition();
	});
});