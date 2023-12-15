#include <fstream>
#include <iostream>
#include <string>

int main()
{
	int sum{ 0 };
	int lineNr = 0;
	std::ifstream inputFile{ "input.txt" };
	if(!inputFile)
	{
		std::cerr << "The input file could not be loaded.\n";
		return 1;
	}

	while(inputFile)
	{
		char firstNumber{ '\0' };
		char lastNumber{ '\0' };

		std::string line;
		std::getline(inputFile, line);
		if(line.empty())
		{
			break;
		}

		// Assumptions : first and last numbers aren't 0
		// There is always 2 or more numbers in a line
		for(char& c : line)
		{
			if(isdigit(c))
			{
				if(firstNumber == '\0')
				{
					firstNumber = c;
					lastNumber = c;
				}
				else
				{
					lastNumber = c;
				}
			}
		}

		std::string values{ firstNumber };
		values += lastNumber;
		std::cout << "Values (" << lineNr << ") : " << values << "\n";
		sum += std::stoi(values);
		lineNr++;
	}

	std::cout << "Sum = " << sum << "\n";
}
