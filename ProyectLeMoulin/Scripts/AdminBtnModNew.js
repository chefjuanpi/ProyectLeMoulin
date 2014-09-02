    $(function () {
        
        //bouton modifier, cacher la barre des boutons modifier, suprimer et nouveau, montre le bouton annuler et active la modification dans le formulaire
        $("#btnmodif").click(function () {
            modif();
        });

        //function modifier, sortie pour le utilliser ulteriorment
        function modif() {
            $("#boutons").hide();
            $("#btnAnuler").show();
            tinymce.activeEditor.getBody().setAttribute('contenteditable', true);
            $("#Formulaire *").attr("disabled", false);
        }

        $("#noPhoto").click(function () {
            $("#photoPrincipal").text("");
            $("#photoPrincipal").val("");
        });

        //bouton Nouveau, cacher la barre des boutons modifier, suprimer et nouveau, montre le formulaire vide prêt pour écrire un nouveau valeur
        $("#btnNew").click(function () {
            $("#boutons").hide();
            $("#Formulaire").show();
            $("#btnAnuler").show();
            $("#Formulaire").find("input[type=text], textarea, input[type=hidden]").val("");
            tinymce.editors[0].setContent("");
            $("#Formulaire *").attr("disabled", false);
            tinymce.activeEditor.getBody().setAttribute('contenteditable', true);
            $("#menuparents option[value='0']").prop('selected', true);
            $("#fb1").prop('checked', true);
            $("#fb1").val(true);
            $("#publier").prop('checked', false);
            $("#publier").publier12();
        });

        //Bouton annuler metre vide le formulaire, le cacher et montre, la barre des boutons modifier, suprimer et nouveau,
        $("#btnAnuler").click(function () {
            $("#boutons").show();
            $("#btnmodif").hide();
            $("#btnSupr").hide();
            $("#Formulaire").hide();
            $("#Formulaire *").attr("disabled", "disabled");
            $("#btnAnuler").hide();
            $("#ItemsList option[value='0']").prop('selected', true);
        });

        //regles de changement de couleur et texte de bouton sauvegarder pour montrer la diferences entre metre public ou non
        $("#publier").change(function () {
            $("#publier").publier12();
        });

        //function pour controler si le checkbox publier est selectionne.
        $.fn.publier12 = function () {
            console.log($(this));
            if ($(this).is(":checked")) {
                $("#save").attr("class", "btn btn-success col-md-offset-1");
                $("#save").html('<i class="fa fa-save"></i><b> Enregistrer</b>');
                $("#fb1").attr("disabled", false);
            } else {
                $("#fb1").attr("disabled", true);
                $("#save").attr("class", "btn btn-danger col-md-offset-1");
                $("#save").html('<i class="fa fa-save"></i><b> Enregistrer sans publier</b>');

            }
            if ($(this).is(":disabled")) {
                $("#fb1").prop('checked', 'checked');
                $("#fb1").attr("disabled", true);
            }
        };

        //ouvre un écran avec le file manager pour selectione l'image principal.
        $("#btnDemoTextBox").click(function () {
            console.log("les details");
            window.open('../tinyfilemanager.net/dialog.aspx?profile=notinymce', 'demo', 'toolbar=0,location=0,status=0,menubar=0,scrollbars=yes,resizable=1,width=900,height=600');
            return false;
        });

        //initialise handelbars
        Templateitems = Handlebars.compile($("#itemsTemplate").html());
    });
