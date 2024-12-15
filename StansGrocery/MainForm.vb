'Justin Bell
'RCET0265
'Stans Grocery
'https://github.com/ju8t1n203/StansGrocery

Option Compare Text
Option Explicit On
Option Strict On

Public Class MainForm

    Private inventory() As String
    Private filteredInventory As New List(Of String)
    Private aisleFilter As String() = {"0", "1", "2", "3", "4", "5",
        "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"}
    Private catagoryFilter As String() = {"Baby stuff", "Baked goods",
        "Baking", "Beverages", "Canned foods", "Cheese",
        "Cleaning products", "Condiments / Sauces", "Dairy",
        "Fresh Fruit", "Fresh Vegetables", "Frozen", "Kitchen",
        "Meat", "Office supplies", "Other stuff", "Personal care",
        "Pets", "Pharmacy", "Seafood", "Snacks", "Spices & herbs",
        "Themed Meals", "Various groceries",
        "Vegetarian College Student"}

    'loading---------------------------
    Private Sub SplashTimer_Tick(sender As Object, e As EventArgs) Handles SplashTimer.Tick
        Me.Show()
        SplashTimer.Enabled = False
        SplashForm.Close()

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadDataFromFile()
        'UpdateComboBox(aisleFilter)
    End Sub

    Private Sub LoadDataFromFile()
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "..\..\..\StansGrocery\My Project\Grocery.txt")
        If IO.File.Exists(filePath) Then
            inventory = IO.File.ReadAllLines(filePath)
        Else
            MessageBox.Show("Data file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'filtering---------------------------
    Private Sub UpdateComboBox(options As String())
        FilterComboBox.Items.Clear()
        FilterComboBox.Items.AddRange(options.ToArray())
    End Sub

    Private Sub FilterByCategory(category As String)
        filteredInventory.Clear()
        DisplayListBox.Items.Clear()

        For Each item As String In inventory
            Dim parts() As String = item.Split(","c)

            If parts.Length >= 3 Then
                Dim categoryPart As String = parts(2).Trim()
                categoryPart = categoryPart.Replace("""", "").Trim()

                'checks if the part contains the category
                If categoryPart = $"%%CAT{category}" Then
                    'extracts and format the item name
                    Dim itemName As String = parts(0).Replace("$$ITM", "").Trim()
                    itemName = itemName.Replace("""", "").Trim()

                    DisplayListBox.Items.Add(itemName)
                    filteredInventory.Add(item)
                End If
            Else
            End If
        Next
    End Sub

    Private Sub FilterByAisle(aisle As String)
        filteredInventory.Clear()
        DisplayListBox.Items.Clear()

        Dim tempList As New List(Of String)

        For Each item As String In inventory
            Dim parts() As String = item.Split(","c)

            If parts.Length >= 3 Then
                Dim aislePart As String = parts(1).Trim()
                aislePart = aislePart.Replace("""", "").Trim()

                'checks if the part contains the aisle
                If aislePart = $"##LOC{aisle}" Then
                    'extracts and formats the item name
                    Dim itemName As String = parts(0).Replace("$$ITM", "").Trim()
                    itemName = itemName.Replace("""", "").Trim()

                    tempList.Add(itemName)

                    filteredInventory.Add(item)
                End If
            Else
            End If
        Next

        'sorts then adds the alphabetical list 
        tempList.Sort()

        For Each itemName As String In tempList
            DisplayListBox.Items.Add(itemName)
        Next
    End Sub

    Private Sub FilterComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterComboBox.SelectedIndexChanged
        Dim selectedOption As String = FilterComboBox.SelectedItem.ToString()

        If FilterbyAisleRadioButton.Checked Then
            FilterByAisle(selectedOption)
        ElseIf FilterbyCategoryRadioButton.Checked Then
            FilterByCategory(selectedOption)
        End If
    End Sub



    Private Sub FilterbyAisleRadioButton_Click(sender As Object, e As EventArgs) Handles FilterbyAisleRadioButton.Click
        UpdateComboBox(aisleFilter)
        DisplayListBox.Items.Clear()
    End Sub

    Private Sub FilterbyCategoryRadioButton_Click(sender As Object, e As EventArgs) Handles FilterbyCategoryRadioButton.Click
        UpdateComboBox(catagoryFilter)
        DisplayListBox.Items.Clear()
    End Sub

    'menus--------------------------------
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
    End Sub

    Private Sub MainForm_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        ContextMenuStrip.Show()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

End Class
