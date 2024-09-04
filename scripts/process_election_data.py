import pandas as pd
import json
import os

# Set the project directory
project_dir = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))

# Set the input and output directories
input_file = os.path.join(project_dir, 'Data', 'countypres_2000-2020.csv')
output_dir = os.path.join(project_dir, 'wwwroot', 'data')

# Ensure the output directory exists
os.makedirs(output_dir, exist_ok=True)

# Load the MIT Election Lab data
df = pd.read_csv(input_file)

# Process data for each year
for year in [2000, 2004, 2008, 2012, 2016, 2020]:
    year_data = df[df['year'] == year]
    
    results = []
    for _, row in year_data.iterrows():
        if row['party'] == 'DEMOCRAT':
            dem_votes = row['candidatevotes']
            total_votes = row['totalvotes']
            dem_percentage = (dem_votes / total_votes) * 100 if total_votes > 0 else 0
            rep_percentage = 100 - dem_percentage  # Simplified to assume only Dem and Rep

            results.append({
                'Year': int(row['year']),
                'CountyFips': str(row['county_fips']).zfill(5),  # Convert to string and ensure 5 digits
                'CountyName': row['county_name'],
                'State': row['state'],
                'DemocratVotePercentage': dem_percentage,
                'RepublicanVotePercentage': rep_percentage
            })

    # Save to JSON
    output_file = os.path.join(output_dir, f'election_results_{year}.json')
    with open(output_file, 'w') as f:
        json.dump(results, f)

print("Data processing complete.")