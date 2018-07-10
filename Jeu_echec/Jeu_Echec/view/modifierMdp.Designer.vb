<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class modifierMdp
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ancien mot de passe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nouveau  mot de passe"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(22, 38)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(219, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.UseSystemPasswordChar = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(22, 88)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(219, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.UseSystemPasswordChar = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(187, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 21)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Enregistrer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(263, 128)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 21)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Annuler"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'modifierMdp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 164)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "modifierMdp"
        Me.Text = "modifierMdp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
