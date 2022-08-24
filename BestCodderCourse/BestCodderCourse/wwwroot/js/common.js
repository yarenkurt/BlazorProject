window.DisplayToastr = (type,message) =>{
    if(type==="success"){
        toastr.success(message,"Operation Successful")
    }else{
        toastr.error(message,"Operation Failed")
    }
}