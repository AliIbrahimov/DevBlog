let deletebtn = document.querySelectorAll(".delete-btn")
console.log(deletebtn)
deletebtn.forEach(elem => {
    elem.addEventListener("click", function (e) {
        e.preventDefault()
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                const url = elem.getAttribute("href")
                fetch(url)
                    .then(res => res.json())
                
                
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }
        })
    })
})