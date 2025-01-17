Imports System.Data.SqlClient


Public Class LOGIN
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtLogin.TextChanged

    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles txtLogin.Click
        txtLogin.Text = ""
        txtLogin.Focus()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub txtPassword_Click(sender As Object, e As EventArgs) Handles txtPassword.Click
        txtPassword.Text = ""
        txtPassword.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cargarusuarios()
        If dataListado.RowCount > 0 Then
            Dispose()
            MENUPRINCIPALMATRICULA.ShowDialog()
        Else
            MessageBox.Show("Verifique su usuario y contraseña", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Sub cargarusuarios()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("validar_usuario", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@login", txtLogin.Text)
            da.SelectCommand.Parameters.AddWithValue("@password", txtPassword.Text)
            da.Fill(dt)
            dataListado.DataSource = dt
            cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class
