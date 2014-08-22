    $(function () {
        //initialisation des parts couvertes de la page, et disabilite le formulaire
        $("#Formulaire *").attr("disabled", "disabled").off('click');

        
        //bouton modifier, cacher la barre des boutons modifier, suprimer et nouveau, montre le bouton annuler et active la modification dans le formulaire
        $("#btnmodif").click(function () {
            $("#boutons").hide();
            $("#btnAnuler").show();
            tinymce.activeEditor.getBody().setAttribute('contenteditable', true);
            $("#Formulaire *").attr("disabled", false).on('click');
            $("#demotextbox").attr("disabled", true);
        });

        //bouton Nouveau, cacher la barre des boutons modifier, suprimer et nouveau, montre le formulaire vide prêt pour écrire un nouveau valeur
        $("#btnNew").click(function () {
            $("#boutons").hide();
            $("#Formulaire").show();
            $("#btnAnuler").show();
            $("#Formulaire").find("input[type=text], textarea, input[type=hidden]").val("");
            $("#publier").prop('checked', false);
            tinymce.editors[0].setContent("");
            $("#Formulaire *").attr("disabled", false).on('click');
            tinymce.activeEditor.getBody().setAttribute('contenteditable', true);
            $("#demotextbox").attr("disabled", true);
            $("#menuparents option[value='0']").prop('selected', true);
        });

        //Bouton annuler metre vide le formulaire, le cacher et montre, la barre des boutons modifier, suprimer et nouveau,
        $("#btnAnuler").click(function () {
            $("#boutons").show();
            $("#btnmodif").hide();
            $("#btnSupr").hide();
            $("#Formulaire").hide();
            $("#Formulaire *").attr("disabled", "disabled").off('click');
            $("#btnAnuler").hide();
            $("#ItemsList option[value='0']").prop('selected', true);
        });

        //ouvre un écren avec le file manager pour selectione l'image principal.
        $("#btnDemoTextBox").click(function () {
            window.open('../tinyfilemanager.net/dialog.aspx?profile=notinymce', 'demo', 'toolbar=0,location=0,status=0,menubar=0,scrollbars=yes,resizable=1,width=900,height=600');
            return false;
        });

        //parametres de ouverture du tinymce
        tfm_path = '/tinyfilemanager.net';
        tinymce.init({
            language : 'fr_FR',
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

        //regles de changement de couleur et texte de bouton sauvegarder pour montrer la diferences entre metre public ou non
        $("#publier").change(function () {
            if ($(this).is(":checked")) {
                $("#save").attr("class", "btn btn-success col-md-offset-3 col-md-2");
                $("#save").html('<i class="fa fa-save"></i><b> Enregistrer</b>');
            } else {
                $("#save").attr("class", "btn btn-danger col-md-offset-3 col-md-2");
                $("#save").html('<i class="fa fa-save"></i><b> Enregistrer sans publier</b>');
            }
        });

        //initialise handelbars
        Templateitems = Handlebars.compile($("#itemsTemplate").html());
    });
