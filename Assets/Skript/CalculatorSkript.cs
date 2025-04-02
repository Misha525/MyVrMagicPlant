using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_Text resultText;
    
    public void Add()
    {
        if (TryGetNumbers(out float num1, out float num2))
            resultText.text = (num1 + num2).ToString();
    }
    
    public void Subtract()
    {
        if (TryGetNumbers(out float num1, out float num2))
            resultText.text = (num1 - num2).ToString();
    }
    
    public void Multiply()
    {
        if (TryGetNumbers(out float num1, out float num2))
            resultText.text = (num1 * num2).ToString();
    }
    
    public void Divide()
    {
        if (TryGetNumbers(out float num1, out float num2))
        {
            if (num2 != 0)
                resultText.text = (num1 / num2).ToString();
            else
                resultText.text = "На нодь делить нельзя!";
        }
    }
    
    private bool TryGetNumbers(out float num1, out float num2)
    {
        bool isValid1 = float.TryParse(inputField1.text, out num1);
        bool isValid2 = float.TryParse(inputField2.text, out num2);
        
        if (!isValid1 || !isValid2)
        {
            resultText.text = "Введите числа!";
            return false;
        }
        return true;
    }
}
