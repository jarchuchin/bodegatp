Imports Microsoft.VisualBasic


Namespace Facturitas

    Public Enum tipoComprobante As Byte
        ingreso
        egreso
        traslado
    End Enum

    Public Enum status As Byte
        procesandose
        terminado
    End Enum

    Public Enum tipoObjeto As Byte
        aduanera
        predial
        complemento
        parte
        concepto
    End Enum

    Public Enum tipoDomicilio As Byte
        fiscal
        expedicion
    End Enum

    Public Enum tipoRetencion As Byte
        ISR
        IVA
    End Enum


    Public Enum tipoTraslado As Byte
        IVA
        IEPS
    End Enum

    Public Enum tipoSerie As Byte
        alfabetico
        alfanumerico
        numerico

    End Enum
End Namespace
