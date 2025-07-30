'引用命名空間
Imports System.Data
Imports System.Linq

Module Module1

    Sub Main()
        '建立DataTable
        Dim dt As New DataTable("MyTable")

        '---------新增欄位(兩種方法)----------
        '第一種新增欄位方式(用Columns Add)
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Name", GetType(String))

        '第二種新增欄位方式(建構DataColumn物件在加進去)
        Dim ColSex As New DataColumn("SEX", GetType(String))
        dt.Columns.Add(ColSex)

        Dim ColBlood As New DataColumn("Blood", GetType(String))
        dt.Columns.Add(ColBlood)

        '--------新增資料(5筆)(兩種方法)----------
        '第一種新增資料方式(用Rows Add)
        dt.Rows.Add(1, "小明", "男", "A")
        dt.Rows.Add(2, "小華", "男", "AB")

        '方法二:使用newRow物件新增資料
        Dim Row3 As DataRow = dt.NewRow()
        Row3("ID") = 3
        Row3("Name") = "小美"
        Row3("SEX") = "女"
        Row3("Blood") = "O"
        dt.Rows.Add(Row3)

        Dim Row4 As DataRow = dt.NewRow()
        Row4("ID") = 4
        Row4("Name") = "小智"
        Row4("SEX") = "男"
        Row4("Blood") = "B"
        dt.Rows.Add(Row4)

        Dim Row5 As DataRow = dt.NewRow()
        Row5("ID") = 5
        Row5("Name") = "小剛"
        Row5("SEX") = "男"
        Row5("Blood") = "AB"
        dt.Rows.Add(Row5

        '------------------------------
        '方法一:使用LINQ 查詢 SEX = '男'
        Console.WriteLine("方法一:使用LINQ查詢 SEX = 男")
        Dim maleRows = From row In dt.AsEnumerable()
                       Where row.Field(Of String)("SEX") = "男"
                       Select row
        For Each row In maleRows
            Console.WriteLine($"{row("ID")}{row("Name")}{row("SEX")}{row("Blood Type")}")
        Next
        '------------------------------
        '方法二:使用DataTable.Select方法
        Console.WriteLine(vbCrLf & "方法二:使用DataTable.Select 查詢SEX=男")
        Dim selectRows As DataRow() = dt.Select("SEX = '男'")

        For Each row As DataRow In selectRows
            Console.WriteLine($"{row("ID")}{row("Name")}{row("SEX")}{row("blood type")}")
        Next

        Console.ReadLine()
    End Sub
End Module