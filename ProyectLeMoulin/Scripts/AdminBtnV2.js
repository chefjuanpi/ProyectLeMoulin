﻿Templateitems = null;
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
});