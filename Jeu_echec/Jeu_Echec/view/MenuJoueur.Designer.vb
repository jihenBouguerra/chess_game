<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuJoueur
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.JouerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficheHistoriqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParametresDuCompteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeconnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JouerToolStripMenuItem, Me.AfficheHistoriqueToolStripMenuItem, Me.ParametresDuCompteToolStripMenuItem, Me.DeconnectionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(585, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'JouerToolStripMenuItem
        '
        Me.JouerToolStripMenuItem.Name = "JouerToolStripMenuItem"
        Me.JouerToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.JouerToolStripMenuItem.Text = "jouer"
        '
        'AfficheHistoriqueToolStripMenuItem
        '
        Me.AfficheHistoriqueToolStripMenuItem.Name = "AfficheHistoriqueToolStripMenuItem"
        Me.AfficheHistoriqueToolStripMenuItem.Size = New System.Drawing.Size(115, 20)
        Me.AfficheHistoriqueToolStripMenuItem.Text = "Affiche Historique"
        '
        'ParametresDuCompteToolStripMenuItem
        '
        Me.ParametresDuCompteToolStripMenuItem.Name = "ParametresDuCompteToolStripMenuItem"
        Me.ParametresDuCompteToolStripMenuItem.Size = New System.Drawing.Size(139, 20)
        Me.ParametresDuCompteToolStripMenuItem.Text = "Parametres du compte"
        '
        'DeconnectionToolStripMenuItem
        '
        Me.DeconnectionToolStripMenuItem.Name = "DeconnectionToolStripMenuItem"
        Me.DeconnectionToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.DeconnectionToolStripMenuItem.Text = "Deconnection"
        '
        'MenuJoueur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 381)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuJoueur"
        Me.Text = "Menu joueur"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents JouerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AfficheHistoriqueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParametresDuCompteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeconnectionToolStripMenuItem As ToolStripMenuItem
End Class
