using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SqlValidator
{
    private static string sqlPattern = @"^(?i)(?<select>select)\s+(?<columns>\*|(?:\w+,\s*)*\w+)\s+(?<from>from)\s+(?<tableName>\w+);$";
    private static string semicolonError = @"[^;]$";
    public static List<string> Validate(string sql)
    {
        Match match = Regex.Match(sql, sqlPattern);
        if (!match.Success)
        {
            return SelectError(sql);
        }
        return null;
    }
    private static List<string> SelectError(string sql)
    {
        List<string> errors = new List<string> { "O comando não está no formato correto. Tente colocá-lo no formato <color=green>SELECT <Lista de Colunas> FROM <Nome da Tabela>;</color>\n" };

        if (Regex.Match(sql, semicolonError).Success)
        {
            errors.Add("O comando deve terminar com um <color=green>;</color>");
        }

        return errors;
    }
}
