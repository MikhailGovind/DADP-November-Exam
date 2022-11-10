/*Script created by R-D
 * Created: 05/11/2022
 * Modified: 06/11/2022 [11:52] by R-D*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Example class that shows the commenting 
 * convention to follow for this project */
public class CommentsExample: MonoBehaviour {

    
    // Function that takes in two integers
    // - returns their sum
    public int MyAdd(int i, int j)
    {
        return i + j;
    }

    // Function that takes in two boundary integers
    // - returns the sum of all the numbers between them; inlcusive of them
    public int MySum(int k, int l)
    {
        int running_sum = 0;    // Variable keeping track of sum between for loop iterations
        for(int m = k; m<=l ;m++) // Sums every no. from k to l using MyAdd function 
        { 
            running_sum = MyAdd(running_sum, m);
        }
        return running_sum;
           

    }



}
