// CrimeData.tsx

import React, { useEffect, useState } from 'react';
import { Container, CircularProgress, Typography } from '@mui/material';
import CrimeChart from './crime-chart';
import { FilterRequest } from '../constant/types';
import { GET_CRIMES_URL } from '../constant/constant';

interface CrimeDataProps {
  filter: FilterRequest;
}

const CrimeData: React.FC<CrimeDataProps> = ({ filter }) => {
  const [crimeData, setCrimeData] = useState<{ name: string; value: number }[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const data = [
    { name: 'Group A', value: 400 },
    { name: 'Group B', value: 300 },
    { name: 'Group C', value: 300 },
    { name: 'Group D', value: 200 },
  ];
  
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(GET_CRIMES_URL
        );

        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        const data = await response.json();
  
        setCrimeData(data);
      } catch (error) {
        setError("Error Occured");
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [filter]);

  if (loading) {
    return (
      <Container>
        <CircularProgress />
      </Container>
    );
  }

  if (error) {
    return (
      <Container>
        <Typography variant="h6" color="error">
          Error: {error}
        </Typography>
      </Container>
    );
  }

  return (
    <Container>
      <Typography variant="h4" gutterBottom>
        Crime Data Chart
      </Typography>
      <CrimeChart data={data} />
    </Container>
  );
};

export default CrimeData;