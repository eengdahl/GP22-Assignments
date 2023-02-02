using UnityEngine;

public class RoomGenerator : TilemapGenerator
{
    public int seed = 0;
    public int numberOfRooms = 3; //number of rooms we want.

    [Header("Room Settings")]
    public int roomMinHight = 4;
    public int roomMaxHeight = 10;
    public int roomMinWidth = 4;
    public int roomMaxWidth = 14;

    //How big do we want our corridors
    //This could also be random between two numbers.
    public int corridorWidth = 3;

    public override void GenerateTilemap()
    {
        //Bygger upp randomfunktionerna i resten av Random. 
        // g�r s� att multiplayer �ver server kan se lika dant ut men byggas lokalt 
      //  Random.InitState(seed);

        //Generate the start room
        int newRoomWidth = Random.Range(roomMinWidth, roomMaxWidth);
        int newRoomHeight = Random.Range(roomMinHight, roomMaxHeight);
        GenerateRoom(startPosition, newRoomWidth, newRoomHeight);

        //Generate our rooms
        for (int i = 0; i < numberOfRooms - 1; i++)
        {
            //Save position of our previous room
            var oldPos = startPosition;

            //Randomize a new room size
            newRoomWidth = Random.Range(roomMinWidth, roomMaxWidth);
            newRoomHeight = Random.Range(roomMinHight, roomMaxHeight);

            //Generates +1 or -1 as a result
            int direction = (Random.Range(0, 2) * 2 - 1);

            //Random if we go in X or Y direction
            if (Random.Range(0, 2) == 0)
                GenerateRoomInDirectionX(newRoomWidth, oldPos, direction);
            else
                GenerateRoomInDirectionY(newRoomHeight, oldPos, direction);

            //Generate Room
            GenerateRoom(startPosition, newRoomWidth, newRoomHeight);
        }
    }

    private void GenerateRoomInDirectionX(int hallwayLength, Vector2Int oldPos, int direction)
    {
        //Set startPosition for the new room depending on the size of the new room
        startPosition.x += direction * Random.Range(hallwayLength + 1, hallwayLength * 2);
        startPosition = ClampVector(startPosition, new Vector2Int(roomMaxWidth / 2, roomMaxHeight / 2));

        //Generates a hallway between the old room and the new.
        int hallwayLenght = Mathf.Abs(Mathf.Abs(startPosition.x) - Mathf.Abs(oldPos.x));
        GenerateRoom((oldPos + startPosition) / 2, hallwayLenght, corridorWidth);
    }

    private void GenerateRoomInDirectionY(int hallwayLength, Vector2Int oldPos, int direction)
    {
        //Set startPosition for the new room depending on the size of the new room
        startPosition.y += direction * Random.Range(hallwayLength + 1, hallwayLength * 2);
        startPosition = ClampVector(startPosition, new Vector2Int(roomMaxWidth / 2, roomMaxHeight / 2));

        //Generates a hallway between the old room and the new.
        int hallwayLenght = Mathf.Abs(Mathf.Abs(startPosition.y) - Mathf.Abs(oldPos.y));
        GenerateRoom((oldPos + startPosition) / 2, corridorWidth, hallwayLenght);
    }

    private void GenerateRoom(Vector2Int roomPosition, int roomWidth, int roomHeight)
    {
        //Randomize the perlin noise for each room
        Vector2 noiseOffset = new Vector2(Random.Range(0, 1f), Random.Range(0, 1f));

        //for each tile in the room
        for (int x = 0; x < roomWidth; x++)
        {
            int yOffset = 0;
            //If the room isn't to small add vertical noise.
            if (roomHeight > 3 && roomMinWidth > 3)
            {
                float value = Mathf.PerlinNoise(x * 0.05f + noiseOffset.x, x * 0.05f + noiseOffset.y);
                yOffset = Mathf.RoundToInt(value * 6) - 3;
            }

            for (int y = 0; y < roomHeight; y++)
            {
                //transfer the room to the buffer
                var newPos = new Vector2Int();
                newPos.x = roomPosition.x + x - roomWidth / 2;
                newPos.y = roomPosition.y + y - roomHeight / 2 - yOffset;
                newPos = ClampVector(newPos, new Vector2Int());

                bufferMap[newPos.x, newPos.y] = true;
            }
        }
    }
}