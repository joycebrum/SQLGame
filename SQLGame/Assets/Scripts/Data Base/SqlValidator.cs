using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SqlValidator
{
    /*private static string tableNamePattern = @"\w+(?:\s+\w+)?";
    private static string returnPattern = @"\*|(?:\w+,\s*)*\w+";
    private static string joinClausePattern = @"\s+(?:inner|left|right|full\s+outer)?\s+join\s+(?<innerTable>\w+(?<innerAlias>\s+\w+)?)\s+on\s+(?:\w+\.\w+\s+=\s+\w+\.\w+)";
    private static string wherePattern = @"\s+where\s+[\w=<>\s']+";*/

    public static List<string> Validate(string sql)
    {
        return SelectError(sql);
    }
    private static List<string> SelectError(string sql)
    {
        List<string> errors = new List<string>();

        CheckRule(sql, @"[^;]$", errors, "O comando deve terminar com um <color=green>;</color>");
        CheckRule(sql, @"(?i)^(?<select>select)\s+(?<columns>\*\s+(?:\w+,?)+)\s+from", errors, "Se for utilizado o <color=green>*</color> para retorno no select, nenhuma outra coluna deve ser listada");

        return errors;
    }

    private static void CheckRule(string sql, string rule, List<string> errors, string errorMsg)
    {
        if (Regex.Match(sql, rule).Success)
        {
            errors.Add(errorMsg);
        }
    }
}
