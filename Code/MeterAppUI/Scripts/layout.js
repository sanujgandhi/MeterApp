        $(document).ready(function () {

            //Handles menu drop down
            $('.dropdown-menu').find('form').click(function (e) {
                e.stopPropagation();
            });


            var trigger = $('.hamburger'),
                overlay = $('.overlay'),
               isClosed = false;

            function hamburger_cross() {

                if (isClosed == true) {
                    overlay.hide();
                    trigger.removeClass('is-open');
                    trigger.addClass('is-closed');
                    isClosed = false;
                } else {
                    overlay.show();
                    trigger.removeClass('is-closed');
                    trigger.addClass('is-open');
                    isClosed = true;
                }
            }

            trigger.click(function () {
                hamburger_cross();
            });
            $('[data-toggle="offcanvas"]').click(function () {
                $('#wrapper').toggleClass('toggled');
            });

            $('.navbar-lower').affix({
                offset: { top: 0 }
            });
        });