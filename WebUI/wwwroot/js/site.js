 $('#datepicker').datepicker({
            uiLibrary: 'bootstrap4',
            format:'dd/mm/yyyy'
        }); 

        $(document).ready(function() {
            $('.input-validation-error').addClass('is-invalid');
            $('.field-validation-error').addClass('text-danger');
        });