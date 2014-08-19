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
        $("#Formulaire *").attr("disabled", false).on('click');
    });

    $("#btnNew").click(function () {
        $("#boutons").hide();
        $("#Formulaire").show();
        $("#btnAnuler").show();
        $("#Formulaire").find("input[type=text], textarea, input[type=hidden]").val("");
        $("#publier").prop('checked', false);
        $("#Formulaire *").attr("disabled", false).on('click');
    });

    $("#btnAnuler").click(function () {
        $("#boutons").show();
        $("#btnmodif").hide();
        $("#btnSupr").hide();
        $("#btnAnuler").hide();
        $("#Formulaire *").attr("disabled", "disabled").off('click');
        $("#Formulaire").hide();
        $("#ItemsList option[value='0']").prop('selected', true);
    });

    Templateitems = Handlebars.compile($("#itemsTemplate").html());
});