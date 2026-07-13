document.addEventListener("DOMContentLoaded", () => {

    setTimeout(() => {

        document
            .querySelectorAll(".alert")
            .forEach(alert => {

                alert.remove();

            });

    }, 4000);

});
