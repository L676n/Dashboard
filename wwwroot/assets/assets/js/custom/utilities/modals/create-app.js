"use strict";
var KTCreateApp=function(){var e,t,o,r,a,i,n=[];
    return{init:function()
        {
          
            (
        e=document.querySelector("#kt_modal_create_app"))&&(new bootstrap.Modal(e),
        t=document.querySelector("#kt_modal_create_app_stepper"),
        o=document.querySelector("#kt_modal_create_app_form"),
        r=t.querySelector('[data-kt-stepper-action="submit"]'),
        a=t.querySelector('[data-kt-stepper-action="next"]'),
        (
        i=new KTStepper(t)).on("kt.stepper.changed",
        (
        function(e){
        4===i.getCurrentStepIndex()?(
        r.classList.remove("d-none"),
        r.classList.add("d-inline-block"),a.classList.add("d-none")):
        5===i.getCurrentStepIndex()?(r.classList.add("d-none"),
        a.classList.add("d-none")):(r.classList.remove("d-inline-block")
        ,r.classList.remove("d-none"),a.classList.remove("d-none"))}))
        ,i.on("kt.stepper.next",(function(e){
        console.log("stepper.next");
        var t=n[e.getCurrentStepIndex()-1];
        t?t.validate().then((function(t)
        {
        console.log("validated!"),
        "Valid"==t?e.goNext():Swal.fire({text:"Sorry, looks like there are some errors detected, please try again.",icon:"error",
        buttonsStyling:!1,confirmButtonText:"Ok, got it!",
        customClass:{confirmButton:"btn btn-light"}}).then((function(){}))})):(e.goNext(),
        KTUtil.scrollTop())})),i.on("kt.stepper.previous",
        (
        function(e){
        console.log("stepper.previous"),e.goPrevious(),KTUtil.scrollTop()})),
        r.addEventListener("click",(function(e){n[3].validate().then((function(t)
            {console.log("validated!"),"Valid"==t?(e.preventDefault(),
            r.disabled=!0,r.setAttribute("data-kt-indicator","on"),
            setTimeout((function(){r.removeAttribute("data-kt-indicator"),
            r.disabled=!1,i.goNext()}),2e3)):Swal.fire({text:"Sorry, looks like there are some errors detected, please try again.",
            icon:"error",buttonsStyling:!1,confirmButtonText:"Ok, got it!",customClass:{confirmButton:"btn btn-light"}})
            .then((function(){KTUtil.scrollTop()}))}))})),$(o.querySelector('[name="card_expiry_month"]'))
            .on("change",(function(){n[3].revalidateField("card_expiry_month")})),
            $(o.querySelector('[name="card_expiry_year"]'))
            .on("change",(function()
            {
            n[3].revalidateField("card_expiry_year")})),
            n.push(
                FormValidation.
                formValidation(o,{fields:{   
                name:{validators:{notEmpty:{message:"App name is required"}}},
                phone:{validators:{notEmpty:{message:"Phone is required"}}},
                idcard:{validators:{notEmpty:{message:"Id is required"}}},
                Nationality:{validators:{notEmpty:{message:""}}},
                email:{validators:{notEmpty:{message:"Email is required"}}}},
                
              
            plugins:{
                trigger:new FormValidation.plugins.Trigger,
                bootstrap:new FormValidation.plugins.Bootstrap5(
                    {
                rowSelector:".fv-row",eleInvalidClass:"",eleValidClass:""})}})),
            n.push(FormValidation.formValidation(o,{fields:{Framework2:{validators:{notEmpty:{message:"Please Enter The Pin Code"}}}}
            ,plugins:{trigger:new FormValidation.plugins.Trigger,
                bootstrap:new FormValidation.plugins.Bootstrap5({rowSelector:".fv-row",eleInvalidClass:"",eleValidClass:""})}})),
                n.push(FormValidation.formValidation(o,{fields:{
                    dbname:{validators:{notEmpty:{message:"RG name is required"}}},
                    cmpname:{validators:{notEmpty:{message:"Company Name  is required"}}}
                
                ,dbengine:{validators:{notEmpty:{message:"Database engine is required"}}}}
                ,plugins:{trigger:new FormValidation.plugins.Trigger,
                bootstrap:new FormValidation.plugins.Bootstrap5({rowSelector:".fv-row",eleInvalidClass:"",eleValidClass:""})}}))
                ,n.push(FormValidation.formValidation(o,{fields:{    
                    
                    customFile:{validators:{notEmpty:{message:"RG COmpany FIle is required"}}},
                    CvFile:{validators:{notEmpty:{message:"Cv File FIle is required"}}},
                    filestructure:{validators:{notEmpty:{message:"Cv File FIle is required"}}},
                    filecmp:{validators:{notEmpty:{message:"Cv File Company is required"}}},
                    reg:{validators:{notEmpty:{message:"region  is required"}}},
                    city:{validators:{notEmpty:{message:"City  is required"}}},
                    bankfile:{validators:{notEmpty:{message:"Bank FIle  Company is required"}}}},              
                    plugins:{trigger:new FormValidation.plugins.Trigger,bootstrap:new FormValidation.plugins.Bootstrap5({rowSelector:".fv-row",eleInvalidClass:"",eleValidClass:""})}})))}}}();
        KTUtil.onDOMContentLoaded((function(){KTCreateApp.init()}));