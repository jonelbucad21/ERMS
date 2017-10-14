    $(function () {
        var lettertypeSelect = $("#LetterType-Select");
        $.ajax({
            type: "GET",
            url: "api/Lettertypes",
            success: function (letterTypes) {
                $.each(letterTypes, function (i, letterType) {
                    lettertypeSelect.append('<option>' + letterType.Name + '</option>');
                });

            }

        });
    });