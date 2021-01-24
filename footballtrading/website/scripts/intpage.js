var tl = new TimelineMax({onUpdate:updatePercentage});
var tl2 = new TimelineMax({onUpdate:updatePercentage});
var tl3 = new TimelineMax({onUpdate:updatePercentage});

const controller = new ScrollMagic.Controller();

tl.from('.slq', .5, {x:200, opacity: 0});
tl.from('.spn', 1, { width: 0}, "=-.5");
tl.from('#img1', 1, {x:-200, opacity: 0,ease: Power4.easeInOut}, "=-1");
tl.from('#img2', 1, {x:200, opacity: 0, ease: Power4.easeInOut}, "=-.7");
tl.from('#arrd2', 1, {x:200, opacity: 0, ease: Power4.easeInOut}, "=-1.2");


tl2.from('.slq2', .5, {x:200, opacity: 0});
tl2.from('.spn2', 1, { width: 0}, "=-.5");
tl2.from('#img3', 1, {y:200, opacity: 0,ease: Power4.easeInOut}, "=-1");
tl2.from('#img4', 1, {y:200, opacity: 0, ease: Power4.easeInOut}, "=-1");
tl2.from('#img5', 1, {y:200, opacity: 0,ease: Power4.easeInOut}, "=-1");
tl2.from('#img6', 1, {y:-200, opacity: 0, ease: Power4.easeInOut}, "=-1");
tl2.from('#img7', 1, {y:-200, opacity: 0,ease: Power4.easeInOut}, "=-1");
tl2.from('#img8', 1, {y:-200, opacity: 0, ease: Power4.easeInOut}, "=-1");
tl2.from('#arrd4', 1, {x:200, opacity: 0, ease: Power4.easeInOut}, "=-1.2");

tl3.from('.slq3', .5, {x:200, opacity: 0});
tl3.from('.spn3', 1, { width: 0}, "=-.5");
tl3.from('#img10', 1, {y:200, opacity: 0, ease: Power4.easeInOut}, "=-.7");
tl3.from('#arrd3', 1, {x:200, opacity: 0, ease: Power4.easeInOut}, "=-.8");

const scene = new ScrollMagic.Scene({
  triggerElement: ".sticky",
            triggerHook: "onLeave",
            duration: "100%"
})
  .setPin(".sticky")
  .setTween(tl)
		.addTo(controller);

const scene2 = new ScrollMagic.Scene({
    triggerElement: ".sticky2",
                triggerHook: "onLeave",
                duration: "100%"
    })
    .setPin(".sticky2")
    .setTween(tl2)
            .addTo(controller);
          
const scene3 = new ScrollMagic.Scene({
    triggerElement: ".sticky3",
                triggerHook: "onLeave",
                duration: "100%"
    })
    .setPin(".sticky3")
    .setTween(tl3)
            .addTo(controller);

function updatePercentage() {
  //percent.innerHTML = (tl.progress() *100 ).toFixed();
  tl.progress();
  console.log(tl.progress());
}
function onLinkClick() {
  document.getElementById('img2').scrollIntoView();
  // will scroll to 4th h3 element
}
$('arrd').click( function(e) {
  document.getElementById('img2').scrollIntoView();
} );