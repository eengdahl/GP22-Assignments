using Unity.Mathematics;
using UnityEngine;

class EmiEng : IRandomWalker
{
    float width;
    float height;
    float maxWidth;
    float maxHeight;
    int insert;


    public string GetName()
    {
        return "Emil Engdahl"; 
    }

    public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
    {
        maxWidth = playAreaWidth;
        maxHeight = playAreaHeight;
        //Select a starting position or use a random one.
        float x = UnityEngine.Random.Range(0, playAreaWidth / 3);
        float y = UnityEngine.Random.Range(0, playAreaHeight / 3);
        math.round(x);
        math.round(y);
        height = y;
        width = x;
        //a PVector holds floats but make sure its whole numbers that are returned!
        return new Vector2(x, y);
    }

    public Vector2 Movement()
    {

        if (width < 3)
        {
            insert = 1;
        }
        else if (width > (maxWidth - 5))
        {
            insert = 0;
        }
        else if (height < 5)
        {
            insert = 2;
        }
        else if (height > (maxHeight - 5))
        {
            insert = 3;
        }

        else
        {
            insert = UnityEngine.Random.Range(0, 4);
        }
        switch (insert)
        {
            case 0:
                width--;
                return new Vector2(-1, 0);
            case 1:
                width++;
                return new Vector2(1, 0);
            case 2:
                height++;
                return new Vector2(0, 1);
            default:
                height--;
                return new Vector2(0, -1);
        }
    }
}
