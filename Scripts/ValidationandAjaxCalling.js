$(document).ready(function () {

    $('#DepartmentId').change(function () {
        var DepartmentId = $(this).val();

        $.ajax({
            url: '/Employee/getDepartmentByOtherdept',
            type: 'GET',
            data: { DepartmentId: DepartmentId },
            dataType: 'json',
            success: function (data) {
                var options = '<option value="">-- Select Other Department --</option>';
                $.each(data, function (key, item) {
                    options += '<option value="' + item.OtherDepartmentID + '">' + item.OtherDepartmentName + '</option>';
                });
                $('#OtherDepartmentId').html(options);
            }
        });
    });

    $('#CountryId').change(function () {
        var countryId = $(this).val();

        $.ajax({
            url: '/Employee/GetStatesByCountry',
            type: 'GET',
            data: { countryId: countryId },
            dataType: 'json',
            success: function (data) {
                var options = '<option value="">-- Select State --</option>';
                $.each(data, function (key, item) {
                    options += '<option value="' + item.stateID + '">' + item.stateName + '</option>';
                });
                $('#statedropdown').html(options);
            }
        });
    });

    $('#btnSubmit').click(function (e) {
        e.preventDefault();
        var EmpName = $('#EmpName').val().trim();
        var Email = $('#Email').val().trim();
        var CellPhone = $('#CellPhone').val().trim();
        var WorkPhone = $('#WorkPhone').val().trim();
        var EmpCurrentAddress = $('#EmpCurrentAddress').val().trim();
        var EmpPermanentAddress = $('#EmpPermanentAddress').val().trim();
        var EmpDob = $('#EmpDob').val().trim();
        var EmpDOJ = $('#EmpDOJ').val().trim();
        var Jobtitle = $('#Jobtitle').val().trim();
        var DepartmentId = $('#DepartmentId').val();
        var OtherDepartmentId = $('#OtherDepartmentId').val();
        var CountryId = $('#CountryId').val();
        var StateId = $('#statedropdown').val();
        var Age = $('#Age').val().trim();
        var gender = $('input[name="gender"]:checked').val();
        var regex = /^[0-9]+$/;


        var isValid = true;

        if (EmpName === '') {
            $('#EmpNameError').text('Employee Name is required.');
            isValid = false;
        } else {
            $('#EmpNameError').text('');
        }

        if (Age === '') {
            $('#EmpAgeError').text('Employee Age is required.');
            isValid = false;
        } else if (!regex.test(Age)) {


            $('#EmpAgeError').text('Invalid Age. Only digits are allowed.');
            isValid = false;
        } else {
            $('#EmpAgeError').text('');
        }


        if (Email === '') {
            $('#EmailError').text('Email is required.');
            isValid = false;
        } else {
            var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(Email)) {
                $('#EmailError').text('Invalid email format.');
                isValid = false;
            } else {
                $('#EmailError').text('');
            }
        }

        if (WorkPhone === '') {
            $('#WorkPhoneError').text('Cell Phone is required.');
            isValid = false;
        } else {
            var phoneRegex = /^\+?[0-9]{6,14}$/;
            if (!phoneRegex.test(WorkPhone)) {
                $('#WorkPhoneError').text('Invalid phone number format. Use country code.');
                isValid = false;
            } else {
                $('#WorkPhoneError').text('');
            }
        }
        if (CellPhone === '') {
            $('#CellPhoneError').text('Cell Phone is required.');
            isValid = false;
        } else {
            var phoneRegex = /^\+?[0-9]{6,14}$/;
            if (!phoneRegex.test(CellPhone)) {
                $('#CellPhoneError').text('Invalid phone number format. Use country code.');
                isValid = false;
            } else {
                $('#CellPhoneError').text('');
            }
        }

        var gender = $('input[name="Gender"]:checked').val();

        if (!gender) {
            $('#genderError').text('Please select a gender.');
            isValid = false;
        } else {
            $('#genderError').text('');
        }
        if (EmpCurrentAddress === '') {
            $('#EmpCurrentAddressError').text('Current Address is required.');
            isValid = false;
        } else {
            $('#EmpCurrentAddressError').text('');
        }
        if (EmpPermanentAddress === '') {
            $('#EmpPermanentAddressError').text('Permanent Address is required.');
            isValid = false;
        } else {
            $('#EmpPermanentAddressError').text('');
        }

        if (EmpDob === '') {
            $('#EmpDobError').text('Date of Birth is required.');
            isValid = false;
        } else {
            $('#EmpDobError').text('');
        }
        if (EmpDOJ === '') {
            $('#EmpDOJError').text('Date of Joining is required.');
            isValid = false;
        } else {
            $('#EmpDOJError').text('');
        }
        if (Jobtitle === '') {
            $('#JobtitleError').text('Job Title is required.');
            isValid = false;
        } else {
            $('#JobtitleError').text('');
        }

        if (DepartmentId === '') {
            $('#DepartmentIdError').text('Please select a Department.');
            isValid = false;
        } else {
            $('#DepartmentIdError').text('');
        }

        if (OtherDepartmentId === '') {
            $('#OtherDepartmentIdError').text('Please select Other Department details.');
            isValid = false;
        } else {
            $('#OtherDepartmentIdError').text('');
        }
        if (CountryId === '') {
            $('#CountryIdError').text('Please select a Country.');
            isValid = false;
        } else {
            $('#CountryIdError').text('');
        }
        if (StateId === '') {
            $('#StateIdError').text('Please select a State.');
            isValid = false;
        } else {
            $('#StateIdError').text('');
        }


        if (isValid) {
            $('form').submit();
        }
    });


    $('#EmpDob').change(function () {
        var dob = $(this).val();
        if (dob) {
            var today = new Date();
            var birthDate = new Date(dob);
            var age = today.getFullYear() - birthDate.getFullYear();
            $('#Age').val(age);
        }
    });

});