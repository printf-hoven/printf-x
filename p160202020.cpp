#include <iostream>
#include <cstdio>

using namespace std;

int main()
{
	const int DIMEN = 24;

	// fill the canvas with NULLs
	char canvas [DIMEN][DIMEN] = {{0}};

	// the origin will be at (12, 12)
	// so that our drawing is at the middle

	// all the points that satisfy the 
	// equation x^2 + y^2 = 4^2 will be
	// filled as *
	for(int row = 0; row < DIMEN; row++)
	{
		for(int col = 0; col < DIMEN; col++)
		{
			// origin is at the center,
			// so obtain the x and y coordinates
			// of each element with respect to the
			// middle
			int x = col - DIMEN/2;			
			int y = DIMEN/2 - row;

			// x^2 + y^2 = 10^2
			// since we are dealing with
			// integers, we can keep
			// a +/-5 tolerance for nicer looks
			int sumsq = x*x + y*y;

			if((95 < sumsq) && (sumsq < 105))
			{
				canvas[row][col] = '*';
			}
		}
	}

	// print
	for(int row = 0; row < DIMEN; row++)
	{
		for(int col = 0; col < DIMEN; col++)
		{
			// THERE IS A SPACE AFTER %c
			// done for nicer looks
			printf("%c ", canvas[row][col]);
		}

		cout << endl;
	}
	
	return 0;
}

// output of the above program
/*
                    * * * * *
                *               *
            *                       *
          *                           *
        *                               *

      *                                   *

    *                                       *
    *                                       *
    *                                       *
    *                                       *
    *                                       *

      *                                   *

        *                               *
          *                           *
            *                       *
                *               *
                    * * * * *


*/
