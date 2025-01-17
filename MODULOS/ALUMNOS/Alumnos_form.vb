Imports System.Data.SqlClient

Public Class Alumnos_form

    Sub MOSTRAR()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Try
            abrir()
            da = New SqlDataAdapter("mostrar_alumnos", conexion)
            da.Fill(dt)
            dataListado.DataSource = dt
            cerrar()
            multilinea(dataListado)
            dataListado.Columns(1).Visible = False

        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("Insertar_alumnos", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@apellido_Paterno", txtapellidopaterno.Text)
            cmd.Parameters.AddWithValue("@apellido_Materno", txtapellidomaterno.Text)
            cmd.Parameters.AddWithValue("@nombres", txtnombres.Text)
            cmd.Parameters.AddWithValue("@Nro_de_documento", txtdocumento.Text)
            'cmd.Parameters.AddWithValue("@Nacionalidad", txtapellidomaterno.Text)
            'cmd.Parameters.AddWithValue("@Fecha_de_nacimiento", txt.Text)
            'cmd.Parameters.AddWithValue("@Estado_civil", txtpassword.Text)
            'cmd.Parameters.AddWithValue("@Sexo", txtnombre.Text)
            'cmd.Parameters.AddWithValue("@Telefono", txtpassword.Text)
            'cmd.Parameters.AddWithValue("@Departamento", txtnombre.Text)
            'cmd.Parameters.AddWithValue("@Distrito", txtapellidomaterno.Text)
            'cmd.Parameters.AddWithValue("@Direccion", txtpassword.Text)
            'cmd.Parameters.AddWithValue("@Departamento2", txtnombre.Text)
            'cmd.Parameters.AddWithValue("@Provincia2", txtapellidomaterno.Text)
            'cmd.Parameters.AddWithValue("@Telefono1", txtpassword.Text)
            'cmd.Parameters.AddWithValue("@Telefono2", txtnombre.Text)
            'cmd.Parameters.AddWithValue("@Correo", txtapellidomaterno.Text)
            'cmd.Parameters.AddWithValue("@Profesion", txtpassword.Text)
            'cmd.Parameters.AddWithValue("@Local_studio", txtpassword.Text)
            'cmd.Parameters.AddWithValue("@Fecha_de_matricula", txtnombre.Text)
            'cmd.Parameters.AddWithValue("@Fecha_de_inicio", txtapellidomaterno.Text)
            'cmd.Parameters.AddWithValue("@Codigo", txtpassword.Text)
            cmd.ExecuteNonQuery()

            cerrar()
            MOSTRAR()
            Panel6.Visible = False

        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtapellidopaterno.TextChanged

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Alumnos_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MOSTRAR()
        Panel6.Visible = False
        txtapellidomaterno.Clear()
        txtapellidopaterno.Clear()
        txtdocumento.Clear()
        txtnombres.Clear()
        GuardarToolStripMenuItem.Visible = True
        btnguardarcambios.Visible = False

    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        Panel6.Visible = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel6.Visible = False

    End Sub

    Private Sub btnguardarcambios_Click(sender As Object, e As EventArgs) Handles btnguardarcambios.Click
        Try
            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("editar_alumno", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@apellido_Paterno", txtapellidopaterno.Text)
            cmd.Parameters.AddWithValue("@apellido_Materno", txtapellidomaterno.Text)
            cmd.Parameters.AddWithValue("@nombres", txtnombres.Text)
            cmd.Parameters.AddWithValue("@Nro_de_documento", txtdocumento.Text)
            cmd.ExecuteNonQuery()

            cerrar()
            MOSTRAR()
            Panel6.Visible = False

        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub dataListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataListado.CellContentClick

    End Sub

    Dim id_alumno As Integer
    Private Sub dataListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataListado.CellDoubleClick
        Try
            Panel6.Visible = True
            id_alumno = dataListado.SelectedCells.Item(1).Value
            txtapellidopaterno = dataListado.SelectedCells.Item(2).Value
            txtapellidomaterno = dataListado.SelectedCells.Item(3).Value
            txtnombres = dataListado.SelectedCells.Item(4).Value
            txtdocumento = dataListado.SelectedCells.Item(5).Value


        Catch ex As Exception

        End Try
    End Sub
End Class