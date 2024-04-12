import React from 'react';
import { Box, Container, Grid, Paper, Typography, styled} from '@mui/material';
import CrimeData from '../components/crime-data';
import Home from '../components/map';

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: 'center',
  color: theme.palette.text.secondary,
}));

const HomePage: React.FC = () => {
  return (
    <Container >
     <Box sx={{ flexGrow: 1 }}>
      <Grid marginTop={3} container spacing={2}>
      <Grid xs={6}>
        <Item>
        <Typography variant="h6" gutterBottom>
          <CrimeData apiUrl='http://localhost:5131/v1/Crime'></CrimeData>
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