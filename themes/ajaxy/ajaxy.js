function prettyTransition(){
	var page = window.location.hash.substr(1);
	if(window.location.pathname.split("/")[1] === "admin") return;
	if(window.location.hash.substr(1) === "" || window.location.hash.substr(1) === "/") page = "home";

	$('.content').css({
		left : '50px',
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
		opacity : 0,
		display : 'block'
	});

	setTimeout(function(){
		$.ajax({
			url: '/themes/ajaxy/page.aspx?page=' + page,
			type: 'GET'
		}).done(function(data){
			$('.main').css({
				display : 'block',
				'background-image' : 'url(/themes/ajaxy/images/ajax-loader.gif)'
			});

			$('.content').html(data);
			$('h1#title').text(params.title);

			$('.content').css({
				left : '50px',
				opacity : 0,
				display : 'block'
			});	

			$('.sidebar').css({
				top : '-50px',
				display : 'block',
				opacity : 0
			});

			$('.sidebar *').css({
				display : 'block'
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

				$('.main').css({
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
	if(Modernizr.csstransitions) {
		if(window.location.pathname.split("/")[1] === "admin") {
			$('.main').css({
				opacity : 1,
				'background-image' : 'none'
			});
			return;
		}

		$('.main *').css({
			display: 'none'
		});

		prettyTransition();

		$(window).on('hashchange', function (){
			prettyTransition();
		});

		$('a.internal').live('click', function(e){
			e.preventDefault();
			window.location.hash = $(this).attr('href');
		});
	}
});

