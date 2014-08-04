    Templateitems = null;
    $(function () {
        $("#btnmodif").hide();
        $("#btnSupr").hide();
        $("#btnAnuler").hide();
        $("#Formulaire *").attr("disabled", "disabled").off('click');
        $("#Formulaire").hide();
        $("#dialog-confirm").hide();
        
        $("#btnmodif").click(function () {
            $("#boutons").hide();
            $("#btnAnuler").show();
            tinymce.activeEditor.getBody().setAttribute('contenteditable', true);
            $("#Formulaire *").attr("disabled", false).on('click');
        });

        $("#btnNew").click(function () {
            $("#boutons").hide();
            $("#Formulaire").show();
            $("#btnAnuler").show();
            $("#Formulaire").find("input[type=text], textarea, input[type=hidden]").val("");
            $("#publier").prop('checked', false);
            tinymce.editors[0].setContent("");
            $("#Formulaire *").attr("disabled", false).on('click');
            tinymce.activeEditor.getBody().setAttribute('contenteditable', true);
        });

        $("#btnAnuler").click(function () {
            $("#boutons").show();
            $("#btnmodif").hide();
            $("#btnSupr").hide();
            $("#Formulaire").hide();
            $("#btnAnuler").hide();
        });

        $("#btnDemoTextBox").click(function () {
            window.open('../tinyfilemanager.net/dialog.aspx?profile=notinymce', 'demo', 'toolbar=0,location=0,status=0,menubar=0,scrollbars=yes,resizable=1,width=900,height=600');
            return false;
        });

        tfm_path = '/tinyfilemanager.net';
        tinymce.init({
            selector: "textarea#elm1",
            theme: "modern",
            height: 400,
            plugins: [
                 "advlist autolink link image lists charmap print preview hr anchor pagebreak",
                 "searchreplace wordcount visualblocks visualchars code insertdatetime media nonbreaking",
                 "save table contextmenu directionality emoticons template paste textcolor "
            ],
            toolbar: "print preview searchreplace | undo redo paste | styleselect | bold italic underline | upload |" +
            " alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link unlink " +
            "anchor image media | forecolor backcolor emoticons charmap hr | insertdatetime nonbreaking table |  pagebreak " +
            " visualblocks visualchars code  ",
            style_formats: [
                 { title: 'Bold text', inline: 'b' },
                 { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
                 { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
                 { title: 'Example 1', inline: 'span', classes: 'example1' },
                 { title: 'Example 2', inline: 'span', classes: 'example2' },
                 { title: 'Table styles' },
                 { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
            ]
        });
    });
