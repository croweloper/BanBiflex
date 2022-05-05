$(document).ready(function () {
    $('#div_fecha_visita').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
        language: 'es',
        weekStart: 1,
        daysOfWeekHighlighted: "0",
        todayHighlight: true
    }).on('changeDate', function (ev) {
        var request = {};
        request.COD_CLIENTE = $("#hdn_codigo_cliente").val();
        request.FECHA_VISITA = moment(ev.date).format('DD/MM/YYYY') ;

        $.ajax({
            url: '/GestionComercial/obtenerporfecha',
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            processData: true,
            data: JSON.stringify(request),
            success: function (response) {
                console.log(response);
                if (response.result != false)
                {
                    $("#txt_potencial").val(response.data.POTENCIAL);
                    $("#txt_preparacion").val(response.data.PREPARACION);
                    $("#hdn_codigo_visita").val(response.data.COD_VISITA_GENERAL);
                }
                else {
                    $("#txt_potencial").val("");
                    $("#txt_preparacion").val("");
                    $("#hdn_codigo_visita").val("0");
                }
            },
            failure: function (msg) {
                console.log(msg);
                //  $.unblockUI();
            },
            error: function (xhr, status, error) {
                console.log(error);
                // $.unblockUI();
            },
            complete: function () {
                //  $.unblockUI();
                //$("#prueba").dialog("close")
            }

        });

        });


    $("#btnFilter").on("click", function () {
        var request = {};
        request.RUC = $("#txt_co_vc_ruc_filter").val();
        $.ajax({
            url: '/GestionComercial/obtenerporruc',
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            processData: true,
            data: JSON.stringify(request),
            success: function (response) {
                console.log(response);
                if (response != null) {

                    if (response.data != null) {
                        $("#hdn_codigo_cliente").val(response.data.COD_CLIENTE);
                        $("#txt_ruc").val(response.data.RUC);
                        $("#txt_razon_social").val(response.data.RAZON_SOCIAL);
                        $("#txt_banca").val(response.data.BANCA);
                        $("#txt_funcionario").val(response.data.FUNCIONARIO);
                        $("#txt_grupo_economico").val(response.data.GRUPO_ECONOMICO);
                        $("#txt_servicio_pdh").val(response.data.SERVICIO_PDH);
                        $("#txt_importe_haberes").val(response.data.IMPORTE_HABERES);
                        $("#txt_cant_colaboradores").val(response.data.CANT_COLABORADORES);
                        $("#txt_vol_total_negocios").val(response.data.VOL_NEGOCIOS);
                        $("#txt_vol_pasivos").val(response.data.VOL_PASIVOS);
                        $("#txt_contingentes").val(response.data.CONTINGENTES);
                        $("#txt_deuda_total_banbif").val(response.data.DEUDA_TOTAL);
                        $("#txt_deuda_vencida_banbif").val(response.data.DEUDA_VENCIDA);
                        $("#txt_facturacion").val(response.data.FACTURACION);
                        $("#txt_sow").val(response.data.ANTIGUEDAD);
                        $("#txt_nro_entidades_deudas").val(response.data.NRO_ENTIDADES_DEUDAS);
                        $("#txt_utilidad_operativa_acumulada").val(response.data.UTILIDAD_OPERATIVA_ACUMULADA);

                    }
                    else {
                        $("#hdn_codigo_cliente").val("0");
                        $("#txt_ruc").val("");
                        $("#txt_razon_social").val("");
                        $("#txt_banca").val("");
                        $("#txt_funcionario").val("");
                        $("#txt_grupo_economico").val("");
                        $("#txt_servicio_pdh").val("");
                        $("#txt_importe_haberes").val("");
                        $("#txt_cant_colaboradores").val("");
                        $("#txt_vol_total_negocios").val("");
                        $("#txt_vol_pasivos").val("");
                        $("#txt_contingentes").val("");
                        $("#txt_deuda_total_banbif").val("");
                        $("#txt_deuda_vencida_banbif").val("");
                        $("#txt_facturacion").val("");
                        $("#txt_sow").val("");
                        $("#txt_nro_entidades_deudas").val("");
                        $("#txt_utilidad_operativa_acumulada").val("");
                        $("#txt_potencial").val("");
                        $("#txt_preparacion").val("");
                    }
                }
                else {
                    $("#hdn_codigo_cliente").val("0");
                    $("#txt_ruc").val("");
                    $("#txt_razon_social").val("");
                    $("#txt_banca").val("");
                    $("#txt_funcionario").val("");
                    $("#txt_grupo_economico").val("");
                    $("#txt_servicio_pdh").val("");
                    $("#txt_importe_haberes").val("");
                    $("#txt_cant_colaboradores").val("");
                    $("#txt_vol_total_negocios").val("");
                    $("#txt_vol_pasivos").val("");
                    $("#txt_contingentes").val("");
                    $("#txt_deuda_total_banbif").val("");
                    $("#txt_deuda_vencida_banbif").val("");
                    $("#txt_facturacion").val("");
                    $("#txt_sow").val("");
                    $("#txt_nro_entidades_deudas").val("");
                    $("#txt_utilidad_operativa_acumulada").val("");
                    $("#txt_potencial").val("");
                    $("#txt_preparacion").val("");
                }

                $("#txt_potencial").val("");
                $("#txt_preparacion").val("");
                $("#hdn_codigo_visita").val("0");
                $("#txt_fecha_visita").val("");
              
            },
            failure: function (msg) {
                console.log(msg);
                //  $.unblockUI();
            },
            error: function (xhr, status, error) {
                console.log(error);
                // $.unblockUI();
            },
            complete: function () {
                //  $.unblockUI();
                //$("#prueba").dialog("close")
            }

        });
    });


    $("#btnGuardar").on("click", function () {
        var request = {};
        request.POTENCIAL = $("#txt_potencial").val();
        request.PREPARACION = $("#txt_preparacion").val();
        request.FECHA_VISITA = $("#txt_fecha_visita").val();
        request.COD_USUARIO = 1;
        request.COD_CLIENTE = $("#hdn_codigo_cliente").val();
        request.COD_VISITA_GENERAL = $("#hdn_codigo_visita").val();
       

        $.ajax({
            url: '/GestionComercial/registro_visita',
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            processData: true,
            data: JSON.stringify(request),
            success: function (response) {
                console.log(response);

                $("#txt_ruc").val("");
                $("#txt_razon_social").val("");
                $("#txt_banca").val("");
                $("#txt_funcionario").val("");
                $("#txt_grupo_economico").val("");
                $("#txt_servicio_pdh").val("");
                $("#txt_importe_haberes").val("");
                $("#txt_cant_colaboradores").val("");
                $("#txt_vol_total_negocios").val("");
                $("#txt_vol_pasivos").val("");
                $("#txt_contingentes").val("");
                $("#txt_deuda_total_banbif").val("");
                $("#txt_deuda_vencida_banbif").val("");
                $("#txt_facturacion").val("");
                $("#txt_sow").val("");
                $("#txt_nro_entidades_deudas").val("");
                $("#txt_utilidad_operativa_acumulada").val("");
                $("#txt_potencial").val("");
                $("#txt_preparacion").val("");
            },
            failure: function (msg) {
                console.log(msg);
                //  $.unblockUI();
            },
            error: function (xhr, status, error) {
                console.log(error);
                // $.unblockUI();
            },
            complete: function () {
                //  $.unblockUI();
                //$("#prueba").dialog("close")
            }

        });
    });
});