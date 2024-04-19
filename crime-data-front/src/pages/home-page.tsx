import React, { useState } from 'react';
import { Box, Container, Grid, Paper, Typography, styled } from '@mui/material';
import CrimeData from '../components/crime-data';
import Home from '../components/map';
import Filter from '../components/filter';
import { FilterRequest } from '../constant/types';

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: 'center',
  color: theme.palette.text.secondary,
}));

const HomePage: React.FC = () => {
  const [filter, setFilters] = useState<FilterRequest>();
  const [cityId, setCityId]= useState(0);
  const onChangeFilter = (filter:FilterRequest) => {
    setFilters(filter);

  }
  return (

    <Container >
      <Box sx={{ flexGrow: 1 }}>
        <Grid marginTop={3} container spacing={2}>
          <Grid xs={12}>
            <Filter onChange={onChangeFilter}></Filter>
          </Grid>
          <Grid xs={6}>
            <Item>
              <Typography variant="h6" gutterBottom>
                {filter &&             <CrimeData filter={filter}></CrimeData>}
    
              </Typography>

            </Item>
          </Grid>
          <Grid xs={6}>
            <Item>
              <Typography variant="h6" gutterBottom>
                Map
              </Typography>
              <Home></Home>
            </Item>
          </Grid>
        </Grid>
      </Box>
    </Container>
  );
};

export default HomePage;