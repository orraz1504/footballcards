$( ".card__inner" ).on( "click", function(event) {
    $(this).toggleClass('is-flipped');
    console.log('clicked');
});