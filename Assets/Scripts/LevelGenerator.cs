using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //Sample blocks from where to create new blocks
    public List<LevelBlock> legoBlocks = new List<LevelBlock>();
    //Blocks added to the game 
    List<LevelBlock> currentBlocks = new List<LevelBlock>();

    public Transform initialPoint;
    private static LevelGenerator _sharedInstance;
    public static LevelGenerator sharedInstance // its public but only i can modify it 
    {
        get
        {
            return _sharedInstance;
        }
    }
    private void Awake()
    {
        _sharedInstance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddNewBlock()
    {
        int randNumber = Random.Range(0, legoBlocks.Count - 1);
        var block = Instantiate(legoBlocks[randNumber]); // its the same as using 'new', but its better for unity
        block.transform.SetParent(this.transform); //the block is a child of LevelGenerator
        Vector3 blockPosition = Vector3.zero;
        if(currentBlocks.Count == 0)
        {
            blockPosition = initialPoint.position;
        }
        else
        {
            int lastBlockPos = currentBlocks.Count - 1;
            blockPosition = currentBlocks[lastBlockPos].exitPoint.position; //finishing position of the last block
        }
        block.transform.position = blockPosition;
        currentBlocks.Add(block);
    }
}
