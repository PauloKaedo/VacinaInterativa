using System;

[Serializable]
public class QuestionObject
{
    public int index;
    public string partnerKey;
    public int environmentLevel;
    public string clue;
    public string question;
    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;

    public QuestionObject() { }

    public QuestionObject(int index, string partnerKey, int environmentLevel, string clue, string question, string answer1, string answer2, string answer3, string answer4)
    {
        this.index = index;
        this.partnerKey = partnerKey;
        this.environmentLevel = environmentLevel;
        this.clue = clue;
        this.question = question;
        this.answer1 = answer1;
        this.answer2 = answer2;
        this.answer3 = answer3;
        this.answer4 = answer4;
    }

    public QuestionObject Clone()
    {
        return (QuestionObject)this.MemberwiseClone();
    }
}
