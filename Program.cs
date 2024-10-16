//*****************************************************************************
//** 1405. Longest Happy String    leetcode                                  **
//*****************************************************************************


/*
char* longestDiverseString(int a, int b, int c) {
    int alphadog = a - (b + c);
    int betamax = b - (a + c);
    int gammaray = c - (a + b);
    if(alphadog % 3 == 0) 
    {
        return("");
    }
    if(betamax % 3 == 0)
    {
        return("");    
        }
    if(gammaray % 3 == 0) 
    {
        return("");   
    }
    int len = a + b + c;
    char* happy =  (char *)malloc((a + b + c + 1) * sizeof(char));
    for(int i = 0; i < len; i++)
    {

            happy = strcat(happy,"a");

    }
    return happy;
}

*/

char* longestDiverseString(int a, int b, int c) {
    // Allocate memory for the result (worst case scenario)
    char *result = (char *)malloc((a + b + c + 1) * sizeof(char));
    int size = 0;
    
    // Store the counts of 'a', 'b', and 'c'
    char ch[3] = {'a', 'b', 'c'};
    int counts[3] = {a, b, c};

    while (1) {
        // Find the character with the highest count
        int maxIdx = -1;
        for (int i = 0; i < 3; i++) {
            if (counts[i] > 0 && (maxIdx == -1 || counts[i] > counts[maxIdx])) {
                maxIdx = i;
            }
        }

        if (maxIdx == -1) break;  // No more characters to add
        
        int n = size;
        // Check if adding this character would result in 3 consecutive same characters
        if (n >= 2 && result[n - 1] == ch[maxIdx] && result[n - 2] == ch[maxIdx]) {
            // Find the second highest character that is not the same as the highest one
            int secondMaxIdx = -1;
            for (int i = 0; i < 3; i++) {
                if (counts[i] > 0 && i != maxIdx && (secondMaxIdx == -1 || counts[i] > counts[secondMaxIdx])) {
                    secondMaxIdx = i;
                }
            }

            if (secondMaxIdx == -1) break;  // No other characters available to add

            // Add the second most frequent character
            result[size++] = ch[secondMaxIdx];
            counts[secondMaxIdx]--;
        } else {
            // Add the most frequent character
            result[size++] = ch[maxIdx];
            counts[maxIdx]--;
        }
    }

    // Null-terminate the string
    result[size] = '\0';
    return result;  // Return the generated string
}